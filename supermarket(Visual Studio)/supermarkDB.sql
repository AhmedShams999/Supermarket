ALTER proc Useradd

@UserName varchar(50),
@password varchar(50),
@E_mail   varchar(50),
@phoneNumber int
AS
  insert into TPLuser (UserName,password,E_mail,phoneNumber)
  values (@UserName,@password,@E_mail,@phoneNumber)