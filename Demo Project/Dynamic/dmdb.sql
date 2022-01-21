CREATE TABLE user_log (
id int identity(1,1) not null primary key,
email VARCHAR(255),
password VARCHAR(255),
username VARCHAR(255),
)

select * from user_log

INSERT INTO user_log ("email","password", "username" )
VALUES ('admin','hvp@admin', 'admin');

CREATE TABLE idea_entry (
id int identity(1,1) not null primary key,
headings VARCHAR(255),
itags VARCHAR(255),
inotes VARCHAR(255),
)

select * from idea_entry

CREATE TABLE user_entry (
id int identity(1,1) not null primary key,
comp_name VARCHAR(255),
ctags VARCHAR(255),
caddress VARCHAR(255),
cemail VARCHAR(255),
caltemail VARCHAR(255),
cmobile VARCHAR(255),
caltmobile VARCHAR(255),
addnotes VARCHAR(255),
)

CREATE TABLE tags_master (
id int identity(1,1) not null primary key,
tags VARCHAR(255),
)
