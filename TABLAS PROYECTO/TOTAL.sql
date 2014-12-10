--------------------------------------------------------
-- Archivo creado  - mi�rcoles-diciembre-10-2014   
--------------------------------------------------------
DROP TABLE "C##EJEMPLO1"."ARTICULOS" cascade constraints;
DROP TABLE "C##EJEMPLO1"."COMPOSICIONES" cascade constraints;
DROP TABLE "C##EJEMPLO1"."MEDIDAS" cascade constraints;
DROP TABLE "C##EJEMPLO1"."PEDIDOS" cascade constraints;
DROP TABLE "C##EJEMPLO1"."PEDIDOSARTICULOS" cascade constraints;
DROP TABLE "C##EJEMPLO1"."USUARIOS" cascade constraints;
DROP TABLE "C##EJEMPLO1"."ROLES" cascade constraints;
DROP TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" cascade constraints;
DROP TABLE "C##EJEMPLO1"."TIPOCAMBIO" cascade constraints;
DROP TABLE "C##EJEMPLO1"."FORMASDEPAGO" cascade constraints;
--------------------------------------------------------
--  DDL for Table ARTICULOS
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."ARTICULOS" 
   (	"IDARTICULO" NUMBER, 
	"REFCOMPOSICION" NUMBER, 
	"REFMEDIDA" NUMBER, 
	"PRECIO" FLOAT(126), 
	"ELIMINADO" NUMBER, 
	"NOMBRE" VARCHAR2(50 BYTE), 
	"REFERENCIA" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;

   COMMENT ON COLUMN "C##EJEMPLO1"."ARTICULOS"."ELIMINADO" IS '0: NO ELIMINADO 1: ELIMINADO ';
--------------------------------------------------------
--  DDL for Table COMPOSICIONES
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."COMPOSICIONES" 
   (	"IDCOMPOSICION" NUMBER(*,0), 
	"COMPOSICION" VARCHAR2(40 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table MEDIDAS
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."MEDIDAS" 
   (	"IDMEDIDA" NUMBER(*,0), 
	"MEDIDA" VARCHAR2(40 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table PEDIDOS
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."PEDIDOS" 
   (	"IDPEDIDO" NUMBER, 
	"REFCLIENTE" NUMBER, 
	"REFUSUARIO" NUMBER, 
	"FECHA" VARCHAR2(40 BYTE), 
	"REFFORMAPAGO" NUMBER, 
	"TOTAL" NUMBER, 
	"PAGADO" VARCHAR2(20 BYTE), 
	"N_PEDIDO" NUMBER, 
	"ELIMINADO" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;

   COMMENT ON COLUMN "C##EJEMPLO1"."PEDIDOS"."PAGADO" IS 'N o S';
--------------------------------------------------------
--  DDL for Table PEDIDOSARTICULOS
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."PEDIDOSARTICULOS" 
   (	"IDPEDIDOARTICULO" NUMBER, 
	"REFPEDIDO" NUMBER, 
	"REFARTICULO" NUMBER, 
	"CANTIDAD" NUMBER, 
	"PRECIOVENTA" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table USUARIOS
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."USUARIOS" 
   (	"IDUSUARIO" NUMBER(3,0), 
	"NOMBRE" VARCHAR2(30 BYTE), 
	"PASSWORD" VARCHAR2(150 BYTE), 
	"ELIMINADO" NUMBER(1,0), 
	"IDROL" NUMBER(3,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;

   COMMENT ON COLUMN "C##EJEMPLO1"."USUARIOS"."IDUSUARIO" IS 'IDENTIFICC##EJEMPLO1OR DEL USUARIO
';
   COMMENT ON COLUMN "C##EJEMPLO1"."USUARIOS"."NOMBRE" IS 'NOMBRE DEL USUARIO';
   COMMENT ON COLUMN "C##EJEMPLO1"."USUARIOS"."PASSWORD" IS 'CONTRASE�A DE ACCESO';
   COMMENT ON COLUMN "C##EJEMPLO1"."USUARIOS"."ELIMINADO" IS '0 -> NO ELIMINADO 1-> ELIMINADO';
   COMMENT ON COLUMN "C##EJEMPLO1"."USUARIOS"."IDROL" IS 'PERMISOS DEL USUARIO';
--------------------------------------------------------
--  DDL for Table ROLES
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."ROLES" 
   (	"IDROL" NUMBER(1,0), 
	"NOMBREROL" VARCHAR2(30 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;

   COMMENT ON COLUMN "C##EJEMPLO1"."ROLES"."IDROL" IS 'IDENTIFICC##EJEMPLO1OR DEL ROL';
--------------------------------------------------------
--  DDL for Table HISTORIALCAMBIOS
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" 
   (	"IDHISTOCAMBIO" NUMBER(4,0), 
	"IDUSUARIO" NUMBER(3,0), 
	"FECHA" VARCHAR2(20 BYTE), 
	"IDTIPOCAMBIO" NUMBER(4,0), 
	"OBSERVACION" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table TIPOCAMBIO
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."TIPOCAMBIO" 
   (	"IDTIPOCAMBIO" NUMBER(4,0), 
	"DESCRIPCION" VARCHAR2(40 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table FORMASDEPAGO
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."FORMASDEPAGO" 
   (	"IDPAGO" NUMBER(3,0), 
	"FORMAPAGO" VARCHAR2(100 BYTE), 
	"ACTIVO" NUMBER(1,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;

   COMMENT ON COLUMN "C##EJEMPLO1"."FORMASDEPAGO"."IDPAGO" IS 'IDENTIFICADOR DE LA FORMA DE PAGO';
   COMMENT ON COLUMN "C##EJEMPLO1"."FORMASDEPAGO"."ACTIVO" IS '0 -> NO ACTIVO 1-> ACTIVO
';
REM INSERTING into C##EJEMPLO1.ARTICULOS
SET DEFINE OFF;
Insert into C##EJEMPLO1.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('5','0','5','85','1','FUNDA','1457');
Insert into C##EJEMPLO1.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('3','0','3','85','0','MOTO','587');
Insert into C##EJEMPLO1.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('1','2','3','50','0','COLCHON','1234');
Insert into C##EJEMPLO1.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('2','3','4','100','0','COLCHON','4321');
Insert into C##EJEMPLO1.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('4','1','2','58','0','FOTO','1213');
REM INSERTING into C##EJEMPLO1.COMPOSICIONES
SET DEFINE OFF;
Insert into C##EJEMPLO1.COMPOSICIONES (IDCOMPOSICION,COMPOSICION) values ('0','Colch�n Muelles');
Insert into C##EJEMPLO1.COMPOSICIONES (IDCOMPOSICION,COMPOSICION) values ('1','Colch�n Viscoel�stica');
Insert into C##EJEMPLO1.COMPOSICIONES (IDCOMPOSICION,COMPOSICION) values ('2','Colch�n Latex');
Insert into C##EJEMPLO1.COMPOSICIONES (IDCOMPOSICION,COMPOSICION) values ('3','Colch�n Enrollado');
REM INSERTING into C##EJEMPLO1.MEDIDAS
SET DEFINE OFF;
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('0','80 x 180 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('1','80 x 190 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('2','80 x 200 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('3','90 x 180 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('4','90 x 190 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('5','90 x 200 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('6','105 x 180 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('7','105 x 190 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('8','105 x 200 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('9','135 x 180 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('10','135 x 190 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('11','135 x 200 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('12','150 x 180 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('13','150 x 190 cm');
Insert into C##EJEMPLO1.MEDIDAS (IDMEDIDA,MEDIDA) values ('14','150 x 200 cm');
REM INSERTING into C##EJEMPLO1.PEDIDOS
SET DEFINE OFF;
Insert into C##EJEMPLO1.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('2','1','1','10/12/2014','2','85','N','201412101','0');
Insert into C##EJEMPLO1.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('3','1','1','10/12/2014','2','50','N','201412101','0');
Insert into C##EJEMPLO1.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('1','1','1','09/12/2014','3','50','N','20141291','0');
Insert into C##EJEMPLO1.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('4','1','1','10/12/2014','3','85','N','201412103','0');
Insert into C##EJEMPLO1.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('5','1','1','10/12/2014','3','100','N','201412103','0');
REM INSERTING into C##EJEMPLO1.PEDIDOSARTICULOS
SET DEFINE OFF;
Insert into C##EJEMPLO1.PEDIDOSARTICULOS (IDPEDIDOARTICULO,REFPEDIDO,REFARTICULO,CANTIDAD,PRECIOVENTA) values ('1','1','3','1','85');
Insert into C##EJEMPLO1.PEDIDOSARTICULOS (IDPEDIDOARTICULO,REFPEDIDO,REFARTICULO,CANTIDAD,PRECIOVENTA) values ('2','1','1','1','50');
Insert into C##EJEMPLO1.PEDIDOSARTICULOS (IDPEDIDOARTICULO,REFPEDIDO,REFARTICULO,CANTIDAD,PRECIOVENTA) values ('3','3','3','1','85');
Insert into C##EJEMPLO1.PEDIDOSARTICULOS (IDPEDIDOARTICULO,REFPEDIDO,REFARTICULO,CANTIDAD,PRECIOVENTA) values ('4','3','2','1','100');
REM INSERTING into C##EJEMPLO1.USUARIOS
SET DEFINE OFF;
Insert into C##EJEMPLO1.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('4','Luis','$2a$10$woQp6bc2w3UgMrbSftRImuOUlzV/sX62u9y9eJi.vWpA3S.quJwne','0','2');
Insert into C##EJEMPLO1.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('2','Carlos','$2a$10$JIXWxPhIKHs/Q/P7es/wKuhzk9T7UhP9kubPZEUfDiTNNL0BiWVJ6','1','2');
Insert into C##EJEMPLO1.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('3','Noemi','$2a$10$e2g3pVj6bZhB3XBo4D.WxOJYEcMofMA6fkpwA2uAU43G089Coy0RG','1','3');
Insert into C##EJEMPLO1.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('1','ROOT','$2a$10$o15Ks1bfPYTpWaCvXPqgTOnoxi9wGP9EafD4IyfFB6vGl1Hh4Nq6K','0','1');
Insert into C##EJEMPLO1.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('5','hola','$2a$10$.Bq7z7/YdlZ/YDcnGkQ9summ.vp.j/lOdDLd/sukV79YtE/YVfTpC','0','3');
Insert into C##EJEMPLO1.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('6','usuario','$2a$10$Ucmz7bCpOWT49Kdiiw/A0umgwPkb3Z.TvgWZRdLy1yVUix3QIjb96','0','3');
REM INSERTING into C##EJEMPLO1.ROLES
SET DEFINE OFF;
Insert into C##EJEMPLO1.ROLES (IDROL,NOMBREROL) values ('1','ROOT');
Insert into C##EJEMPLO1.ROLES (IDROL,NOMBREROL) values ('2','ADMINISTRATIVO');
Insert into C##EJEMPLO1.ROLES (IDROL,NOMBREROL) values ('3','OPERATIVO');
REM INSERTING into C##EJEMPLO1.HISTORIALCAMBIOS
SET DEFINE OFF;
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('4','5','01/12/2014','2','Usuario modificado');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('1','4','29/11/2014','3','Usuario borrado');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('2','5','29/11/2014','4','Usuario restaurado');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('3','4','29/11/2014','4','Usuario restaurado');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('5','4','01/12/2014','2','Usuario modificado');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('11','1','10/12/2014','1','Pedido a�adido  num_pedido->201412101');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('12','1','10/12/2014','1','Pedido a�adido  num_pedido->201412101');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('13','1','10/12/2014','1','Articulo a�adido ->FUNDA');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('6','0','02/12/2014','1','A�adido nuevo usuario');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('7','6','02/12/2014','2','Usuario modificado');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('8','1','08/12/2014','1','Articulo a�adido ->FOTO');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('10','1','09/12/2014','1','Pedido a�adido  num_pedido->20141291');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('9','1','09/12/2014','1','Pedido a�adido  num_pedido->20141292');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('14','1','10/12/2014','1','Pedido a�adido  num_pedido->201412103');
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('15','1','10/12/2014','1','Pedido a�adido  num_pedido->201412103');
REM INSERTING into C##EJEMPLO1.TIPOCAMBIO
SET DEFINE OFF;
Insert into C##EJEMPLO1.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('1','A�adido');
Insert into C##EJEMPLO1.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('2','Modificado');
Insert into C##EJEMPLO1.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('3','Borrado');
Insert into C##EJEMPLO1.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('4','Restaurar');
REM INSERTING into C##EJEMPLO1.FORMASDEPAGO
SET DEFINE OFF;
Insert into C##EJEMPLO1.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('1','TARJETA','1');
Insert into C##EJEMPLO1.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('2','CONTRAREEMBOLSO','1');
Insert into C##EJEMPLO1.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('3','PAYPAL','1');
Insert into C##EJEMPLO1.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('4','EFECTIVO','1');
Insert into C##EJEMPLO1.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('5','TRANSFERENCIA','1');
--------------------------------------------------------
--  DDL for Index ARTICULOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."ARTICULOS_PK" ON "C##EJEMPLO1"."ARTICULOS" ("IDARTICULO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SYS_C0010010
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."SYS_C0010010" ON "C##EJEMPLO1"."COMPOSICIONES" ("IDCOMPOSICION") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SYS_C0010011
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."SYS_C0010011" ON "C##EJEMPLO1"."MEDIDAS" ("IDMEDIDA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PEDIDOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."PEDIDOS_PK" ON "C##EJEMPLO1"."PEDIDOS" ("IDPEDIDO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PEDIDOSARTICULOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."PEDIDOSARTICULOS_PK" ON "C##EJEMPLO1"."PEDIDOSARTICULOS" ("IDPEDIDOARTICULO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index USUARIOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."USUARIOS_PK" ON "C##EJEMPLO1"."USUARIOS" ("IDUSUARIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index ROLES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."ROLES_PK" ON "C##EJEMPLO1"."ROLES" ("IDROL") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index HISTORIAL_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."HISTORIAL_PK" ON "C##EJEMPLO1"."HISTORIALCAMBIOS" ("IDHISTOCAMBIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index TIPOCAMBIO_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."TIPOCAMBIO_PK" ON "C##EJEMPLO1"."TIPOCAMBIO" ("IDTIPOCAMBIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index FORMASDEPAGO_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."FORMASDEPAGO_PK" ON "C##EJEMPLO1"."FORMASDEPAGO" ("IDPAGO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table ARTICULOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."ARTICULOS" ADD CONSTRAINT "ARTICULOS_PK" PRIMARY KEY ("IDARTICULO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "C##EJEMPLO1"."ARTICULOS" MODIFY ("IDARTICULO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table COMPOSICIONES
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."COMPOSICIONES" ADD PRIMARY KEY ("IDCOMPOSICION")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table MEDIDAS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."MEDIDAS" ADD PRIMARY KEY ("IDMEDIDA")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table PEDIDOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."PEDIDOS" ADD CONSTRAINT "PEDIDOS_PK" PRIMARY KEY ("IDPEDIDO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "C##EJEMPLO1"."PEDIDOS" MODIFY ("IDPEDIDO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PEDIDOSARTICULOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."PEDIDOSARTICULOS" ADD CONSTRAINT "PEDIDOSARTICULOS_PK" PRIMARY KEY ("IDPEDIDOARTICULO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "C##EJEMPLO1"."PEDIDOSARTICULOS" MODIFY ("IDPEDIDOARTICULO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table USUARIOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."USUARIOS" ADD CONSTRAINT "USUARIOS_PK" PRIMARY KEY ("IDUSUARIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "C##EJEMPLO1"."USUARIOS" MODIFY ("ELIMINADO" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."USUARIOS" MODIFY ("PASSWORD" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."USUARIOS" MODIFY ("NOMBRE" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."USUARIOS" MODIFY ("IDUSUARIO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ROLES
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."ROLES" MODIFY ("NOMBREROL" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."ROLES" MODIFY ("IDROL" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."ROLES" ADD CONSTRAINT "ROLES_PK" PRIMARY KEY ("IDROL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table HISTORIALCAMBIOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("IDHISTOCAMBIO" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("IDUSUARIO" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("FECHA" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("IDTIPOCAMBIO" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("OBSERVACION" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" ADD CONSTRAINT "HISTORIAL_PK" PRIMARY KEY ("IDHISTOCAMBIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table TIPOCAMBIO
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."TIPOCAMBIO" ADD CONSTRAINT "TIPOCAMBIO_PK" PRIMARY KEY ("IDTIPOCAMBIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "C##EJEMPLO1"."TIPOCAMBIO" MODIFY ("IDTIPOCAMBIO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FORMASDEPAGO
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."FORMASDEPAGO" ADD CONSTRAINT "FORMASDEPAGO_PK" PRIMARY KEY ("IDPAGO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "C##EJEMPLO1"."FORMASDEPAGO" MODIFY ("ACTIVO" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."FORMASDEPAGO" MODIFY ("FORMAPAGO" NOT NULL ENABLE);
  ALTER TABLE "C##EJEMPLO1"."FORMASDEPAGO" MODIFY ("IDPAGO" NOT NULL ENABLE);
--------------------------------------------------------
--  Ref Constraints for Table PEDIDOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."PEDIDOS" ADD CONSTRAINT "PEDIDOS_FK1" FOREIGN KEY ("REFUSUARIO")
	  REFERENCES "C##EJEMPLO1"."USUARIOS" ("IDUSUARIO") ENABLE;
  ALTER TABLE "C##EJEMPLO1"."PEDIDOS" ADD CONSTRAINT "PEDIDOS_FPAGO" FOREIGN KEY ("REFFORMAPAGO")
	  REFERENCES "C##EJEMPLO1"."FORMASDEPAGO" ("IDPAGO") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table PEDIDOSARTICULOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."PEDIDOSARTICULOS" ADD CONSTRAINT "PEDIDOSARTICULOS_ARTICULO" FOREIGN KEY ("REFARTICULO")
	  REFERENCES "C##EJEMPLO1"."ARTICULOS" ("IDARTICULO") ENABLE;
  ALTER TABLE "C##EJEMPLO1"."PEDIDOSARTICULOS" ADD CONSTRAINT "PEDIDOSARTICULOS_PEDIDO" FOREIGN KEY ("REFPEDIDO")
	  REFERENCES "C##EJEMPLO1"."PEDIDOS" ("IDPEDIDO") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table HISTORIALCAMBIOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" ADD CONSTRAINT "HISTORIALCAMBIOS_FK1" FOREIGN KEY ("IDHISTOCAMBIO")
	  REFERENCES "C##EJEMPLO1"."HISTORIALCAMBIOS" ("IDHISTOCAMBIO") ENABLE;
