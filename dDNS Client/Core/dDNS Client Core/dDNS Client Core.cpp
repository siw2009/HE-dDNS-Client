#define CURL_STATICLIB
#define CONFIG_ARGUMENTS 4
#define CONFIG_ARGUMENTS_LENGTH 256
#define CONFIG_LABELS {"hostname", "authtoken", "refreshdelay", "dDNSHost"}  // EACH LABEL'S LENGTH MUST NOT EXCEED 255
#include <stdio.h>
#include <curl/curl.h>
#include "dDNS Client Core Header.h"



struct memory {
    char* response;
    size_t size;
};


EXPORT_ struct CurlWorker {
    CURL* curl;
};



EXPORT_ void freeptr(void* ptr) {
    free(ptr);
}


static size_t read_response(char* data, size_t size, size_t members_count, void* response_pointer) {
    size_t realsize = size * members_count;
    struct memory* mem = (struct memory*)response_pointer;

    
    char* rlt_pointer = (char*)realloc(mem->response, mem->size + realsize + 1);
    if (!rlt_pointer)  return 0;

    mem->response = rlt_pointer;
    memcpy(&(mem->response[mem->size]), data, realsize);
    mem->size += realsize;
    mem->response[mem->size] = 0;

    return realsize;
}


EXPORT_ char* read_config(const char* conf_path) {
    /*
    Reads the configuation file from conf_path
    Each configuration argument can be CONFIG_ARGUMENTS_LENGTH - 1 long max.
    Every configuration can have its own label separated by ':'
    */

    FILE* config_filepointer;
    errno_t err = fopen_s(&config_filepointer, conf_path, "r");
    if (err)  return 0;

    byte comment = 0;
    int i = 0, j = 0, c = 0;
    char* result = (char*)malloc(CONFIG_ARGUMENTS * CONFIG_ARGUMENTS_LENGTH);
    if (!result) {
        fclose(config_filepointer);
        return 0;
    }

    memset(result, 0, CONFIG_ARGUMENTS * CONFIG_ARGUMENTS_LENGTH);
    while ((c = getc(config_filepointer)) != EOF && i < CONFIG_ARGUMENTS) {
        switch (c) {
        case '\n':
            i++;
            j = 0;
            comment = 0;
            break;

        case ':':
            comment = 1;
            break;

        default:
            if (comment && j < CONFIG_ARGUMENTS_LENGTH - 1) {
                result[i * CONFIG_ARGUMENTS_LENGTH + j++] = c;
            }
        }
    }

    fclose(config_filepointer);
    return result;
}


EXPORT_ int write_config(const char* conf_path, const char* args) {
    /*
    Writes configuration data of args in to conf_path
    args must be a char array of CONFIG_ARGUMENTS * CONFIG_ARGUMENTS_LENGTH
    Each argument can be up to CONFIG_ARGUMENTS_LENGTH - 1 characters long.
    */

    FILE* config_filepointer;
    errno_t err = fopen_s(&config_filepointer, conf_path, "w");
    if (err)  return 1;

    const char* labels[CONFIG_ARGUMENTS] = CONFIG_LABELS;
    for (int i = 0; i < CONFIG_ARGUMENTS; i++) {
        fprintf(config_filepointer, "%s:%.*s\n", labels[i], CONFIG_ARGUMENTS_LENGTH -1, args + CONFIG_ARGUMENTS_LENGTH * i);
    }

    fclose(config_filepointer);
    return 0;
}


char* make_he_url(const char* target, const char* hostname) {
    size_t result_size = CONFIG_ARGUMENTS_LENGTH * CONFIG_ARGUMENTS + 64;
    char* result = (char*)malloc(result_size);
    if (!result)  return 0;


    result[0] = 0;
    strcat_s(result, result_size, "https://");
    strcat_s(result, result_size, hostname);
    strcat_s(result, result_size, target);
        
    return result;
}


EXPORT_ int refresh_ddns(CurlWorker* curl, const char* base64authheader, const char* target, const char* hostname, char** rlt) {
    /*
    Refreshes ddns by sending GET request to Hurricane Electrics dDNS server.

    base64authheader - must be given in the following format:
    "Authorization: Basic [[base64 encoded string of (hostname):(authtoken)]]"

    Return code
    - 1: cURL initialization error
    - 2: cURL HTTP GET request error
    - 3: memory error
    */
    

    if (curl->curl) {
        struct memory chunk = { 0 };
        struct curl_slist* headers = NULL;
        char* request_url = make_he_url(target, hostname);
        if (!request_url)  return 3;


        curl_easy_setopt(curl->curl, CURLOPT_URL, request_url);
        curl_easy_setopt(curl->curl, CURLOPT_FOLLOWLOCATION, 0L);
        curl_easy_setopt(curl->curl, CURLOPT_WRITEFUNCTION, read_response);
        curl_easy_setopt(curl->curl, CURLOPT_WRITEDATA, (void*)&chunk);

        headers = curl_slist_append(headers, base64authheader);
        if (!headers) {
            curl_slist_free_all(headers);
            return 1;
        }
        curl_easy_setopt(curl->curl, CURLOPT_HTTPHEADER, headers);

        CURLcode res = curl_easy_perform(curl->curl);
        

        free(request_url);
        curl_slist_free_all(headers);
        if (res != CURLE_OK) {
            *rlt = (char*)curl_easy_strerror(res);
            return 2;
        }
        else {
            *rlt = (char*)malloc(chunk.size +1);
            if (!*rlt)  return 3;
            strcpy_s(*rlt, chunk.size +1, chunk.response);
            return 0;
        }
    }
    else {
        return 1;
    }

}


EXPORT_ void refresh_config(const char* conf_path, char* args) {
    char* new_config = read_config(conf_path);
    if (!new_config)  return;

    for (int i = 0; i < CONFIG_ARGUMENTS; i++) {
        strcpy_s(args + CONFIG_ARGUMENTS_LENGTH * i, CONFIG_ARGUMENTS_LENGTH, new_config + CONFIG_ARGUMENTS_LENGTH * i);
    }

    free(new_config);
}


EXPORT_ int start(CurlWorker* curl) {
    curl->curl = curl_easy_init();
    return (curl->curl) ? 0 : 1;
}


EXPORT_ void cleanup(CurlWorker* curl) {
    curl_easy_cleanup(curl->curl);
}


EXPORT_ void close() {
    curl_global_cleanup();
}