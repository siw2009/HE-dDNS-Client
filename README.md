# 백섥이 클라이엔트
A client for syncing to a dDNS service provided by [Hurricane Electric](https://dns.he.net)

This client will run in the background; it will generate an icon on the system tray where you can control it.\
Hovering your cursor over the program will show you a brief information, such as latest sync time and the following server response.

## Menus
Right-clicking on the program will show you several menus.
### Pause
* pauses the program’s clock
* click it back to resume the program
### Update
* sync with the dDNS service immediately
* will display a messagebox with the server’s response
### Settings
* HE dDNS Host: sets dDNS upstream address. defaults to `dyn.dns.he.net/nic/update?hostname=`
* Target: your domain name which you want to sync dDNS with. Enter the authentication token given by Hurrican Electric upon registering the dDNS service
* Refresh Rate: modifies the program’s clock time in seconds.
