drop database if exists `db_MCSales`;
create database `db_MCSales`;
use db_MCSales;

drop table if exists `tbl_permission`;
create table tbl_permission(
permission_id int not null,		
permission_desc varchar (30) not null,
primary key(permission_id)
);

insert into tbl_permission(permission_id, permission_desc) values(1, 'Administrador');
insert into tbl_permission(permission_id, permission_desc) values(2, 'Administração');
insert into tbl_permission(permission_id, permission_desc) values(3, 'Vendas');
insert into tbl_permission(permission_id, permission_desc) values(4, 'Professor');

drop table if exists `tbl_user`;
create table tbl_user(
user_id int not null auto_increment,	
user_name varchar (30) not null,
user_password varchar(12) not null,
permission_id int not null,
primary key(user_id),
foreign key(permission_id) references tbl_permission(permission_id)
);
insert into tbl_user(user_name, user_password, permission_id) values ('Administrador', 'admin', 1);

drop table if exists `tbl_class`;
create table tbl_class(
class_id int not null auto_increment,
class_day varchar (60) not null, -- dia da aula --
class_timesPerWeek int not null, -- quantos dia na semana --
class_hourStarts varchar(30) not null, -- hora que começa --
class_hourEnds varchar (30) not null, -- hora que acaba --
class_duration int not null, -- tempo total de duração -- 
class_type varchar (60) not null,
class_vacancys int not null,
user_id int not null,
primary key(class_id),
foreign key(user_id) references tbl_user(user_id)
);

drop table if exists `tbl_resp`;
create table tbl_resp(
resp_id int not null auto_increment,
resp_name varchar (30) not null,
resp_rg varchar (30) not null,
resp_cpf varchar (30) not null,
resp_birthDate varchar(60),
resp_sex varchar(30) not null,
resp_phone varchar (30) not null,
resp_whatsApp varchar (30) not null,
resp_cep varchar (30) not null,
resp_state varchar (30) not null,
resp_city varchar (30) not null,
resp_block varchar (30) not null,
resp_street varchar (30) not null,
resp_number varchar (30) not null,
resp_obs varchar (1000) not null,
primary key(resp_id)
);

drop table if exists `tbl_student`;
create table tbl_student(
student_id int not null auto_increment,
student_name varchar (30) not null,
student_ctr varchar (10) not null,
student_status varchar (30) not null,
student_subscriptionDate varchar (60),
student_rg varchar (30) not null,
student_cpf varchar (30) not null,
student_birthDate varchar(60),
student_sex varchar(30) not null,
student_phone varchar (30) not null,
student_whatsApp varchar (30) not null,
student_cep varchar (30) not null,
student_state varchar (30) not null,
student_city varchar (30) not null,
student_block varchar (30) not null,
student_street varchar (30) not null,
student_number varchar (30) not null,
student_obs varchar (1000) not null,
class_id int,
resp_id int,
primary key(student_id),	
foreign key(class_id) references tbl_class(class_id),
foreign key(resp_id) references tbl_resp(resp_id)
);