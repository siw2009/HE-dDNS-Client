# 백섥이 클라이엔트
A client for syncing to a dDNS service provided by [Hurricane Electric](https://dns.he.net)

This client will run in the background; it will generate an icon on the system tray where you can control it.\
Hovering your cursor over the program will show you a brief information, such as latest sync time and the following server response.

## Menus
Right-clicking on the program will show you several menus.
### Pause
* Pauses the program’s clock
* Click it back to resume the program
### Update
* Sync with the dDNS service immediately
* Will display a messagebox with the server’s response
### Settings
* HE dDNS Host: Sets dDNS upstream address. defaults to `dyn.dns.he.net/nic/update?hostname=`
* Target: Your domain name which you want to sync dDNS with. Enter the authentication token given by Hurricane Electric upon registering the dDNS service  **\* This is the section YOU want to edit \***
* Refresh Rate: Modifies the program’s clock time in seconds. Defaults to `90` seconds.
