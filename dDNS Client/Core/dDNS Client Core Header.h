#pragma once

#include <stdio.h>
#include <curl/curl.h>



#ifdef __cplusplus
extern "C" {
#endif


#if defined(_WIN32) || defined(_WIN64)
#ifdef DDNS_EXPORTS
#define EXPORT_ __declspec(dllexport)
#else
#define EXPORT_ __declspec(dllimport)
#endif
#else
#define EXPORT_
#endif


    EXPORT_ struct CurlWorker;
    EXPORT_ void freeptr(void* ptr);
    EXPORT_ char* read_config(const char* conf_path);
    EXPORT_ int write_config(const char* conf_path, const char* args);
    EXPORT_ int refresh_ddns(CurlWorker* curl, const char* target, const char* authtoken, const char* hostname, char** rlt);
    EXPORT_ void refresh_config(const char* conf_path, const char* args);
    EXPORT_ int start(CurlWorker* curl);
    EXPORT_ void cleanup(CurlWorker* curl);
    EXPORT_ void close();


#ifdef __cplusplus
}
#endif
