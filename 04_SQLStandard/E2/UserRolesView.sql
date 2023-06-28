CREATE VIEW UserRolesView AS
SELECT u.idUser, CONCAT(u.nom_usu, ' ', u.ap_usu, ' ', u.am_usu) AS nombre, u.email_usu, u.tel_usu, r.nomRol
FROM user u
INNER JOIN userinroles ur ON u.idUser = ur.idUser
INNER JOIN roles r ON ur.idRoles = r.idRoles;
