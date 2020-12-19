


use master;

create database ProjectSourceBackupToolPortal;

create login [PSBT_Web_User] WITH PASSWORD='y{$~JT/9co3g6jJ=Bk';

use ProjectSourceBackupToolPortal;

CREATE USER PSBT_Web_User from login PSBT_Web_User;

alter role db_owner add MEMBER PSBT_Web_User;