--------------------------------------------------------
-- Archivo creado  - mi�rcoles-diciembre-10-2014   
--------------------------------------------------------
DROP TABLE "AD"."ARTICULOS" cascade constraints;
DROP TABLE "AD"."COMPOSICIONES" cascade constraints;
DROP TABLE "AD"."MEDIDAS" cascade constraints;
DROP TABLE "AD"."PEDIDOS" cascade constraints;
DROP TABLE "AD"."PEDIDOSARTICULOS" cascade constraints;
DROP TABLE "AD"."USUARIOS" cascade constraints;
DROP TABLE "AD"."ROLES" cascade constraints;
DROP TABLE "AD"."HISTORIALCAMBIOS" cascade constraints;
DROP TABLE "AD"."TIPOCAMBIO" cascade constraints;
DROP TABLE "AD"."FORMASDEPAGO" cascade constraints;
--------------------------------------------------------
--  DDL for Table ARTICULOS
--------------------------------------------------------

  CREATE TABLE "AD"."ARTICULOS" 
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

   COMMENT ON COLUMN "AD"."ARTICULOS"."ELIMINADO" IS '0: NO ELIMINADO 1: ELIMINADO ';
--------------------------------------------------------
--  DDL for Table COMPOSICIONES
--------------------------------------------------------

  CREATE TABLE "AD"."COMPOSICIONES" 
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

  CREATE TABLE "AD"."MEDIDAS" 
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

  CREATE TABLE "AD"."PEDIDOS" 
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

   COMMENT ON COLUMN "AD"."PEDIDOS"."PAGADO" IS 'N o S';
--------------------------------------------------------
--  DDL for Table PEDIDOSARTICULOS
--------------------------------------------------------

  CREATE TABLE "AD"."PEDIDOSARTICULOS" 
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

  CREATE TABLE "AD"."USUARIOS" 
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

   COMMENT ON COLUMN "AD"."USUARIOS"."IDUSUARIO" IS 'IDENTIFICC##EJEMPLO1OR DEL USUARIO
';
   COMMENT ON COLUMN "AD"."USUARIOS"."NOMBRE" IS 'NOMBRE DEL USUARIO';
   COMMENT ON COLUMN "AD"."USUARIOS"."PASSWORD" IS 'CONTRASE�A DE ACCESO';
   COMMENT ON COLUMN "AD"."USUARIOS"."ELIMINADO" IS '0 -> NO ELIMINADO 1-> ELIMINADO';
   COMMENT ON COLUMN "AD"."USUARIOS"."IDROL" IS 'PERMISOS DEL USUARIO';
--------------------------------------------------------
--  DDL for Table ROLES
--------------------------------------------------------

  CREATE TABLE "AD"."ROLES" 
   (	"IDROL" NUMBER(1,0), 
	"NOMBREROL" VARCHAR2(30 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;

   COMMENT ON COLUMN "AD"."ROLES"."IDROL" IS 'IDENTIFICC##EJEMPLO1OR DEL ROL';
--------------------------------------------------------
--  DDL for Table HISTORIALCAMBIOS
--------------------------------------------------------

  CREATE TABLE "AD"."HISTORIALCAMBIOS" 
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

  CREATE TABLE "AD"."TIPOCAMBIO" 
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

  CREATE TABLE "AD"."FORMASDEPAGO" 
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

   COMMENT ON COLUMN "AD"."FORMASDEPAGO"."IDPAGO" IS 'IDENTIFICADOR DE LA FORMA DE PAGO';
   COMMENT ON COLUMN "AD"."FORMASDEPAGO"."ACTIVO" IS '0 -> NO ACTIVO 1-> ACTIVO
';
REM INSERTING into AD.ARTICULOS
SET DEFINE OFF;
Insert into AD.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('5','0','5','85','1','FUNDA','1457');
Insert into AD.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('3','0','3','85','0','MOTO','587');
Insert into AD.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('1','2','3','50','0','COLCHON','1234');
Insert into AD.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('2','3','4','100','0','COLCHON','4321');
Insert into AD.ARTICULOS (IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA) values ('4','1','2','58','0','FOTO','1213');
REM INSERTING into AD.COMPOSICIONES
SET DEFINE OFF;
Insert into AD.COMPOSICIONES (IDCOMPOSICION,COMPOSICION) values ('0','Colch�n Muelles');
Insert into AD.COMPOSICIONES (IDCOMPOSICION,COMPOSICION) values ('1','Colch�n Viscoel�stica');
Insert into AD.COMPOSICIONES (IDCOMPOSICION,COMPOSICION) values ('2','Colch�n Latex');
Insert into AD.COMPOSICIONES (IDCOMPOSICION,COMPOSICION) values ('3','Colch�n Enrollado');
REM INSERTING into AD.MEDIDAS
SET DEFINE OFF;
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('0','80 x 180 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('1','80 x 190 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('2','80 x 200 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('3','90 x 180 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('4','90 x 190 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('5','90 x 200 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('6','105 x 180 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('7','105 x 190 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('8','105 x 200 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('9','135 x 180 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('10','135 x 190 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('11','135 x 200 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('12','150 x 180 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('13','150 x 190 cm');
Insert into AD.MEDIDAS (IDMEDIDA,MEDIDA) values ('14','150 x 200 cm');
REM INSERTING into AD.PEDIDOS
SET DEFINE OFF;
Insert into AD.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('2','1','1','10/12/2014','2','85','N','201412101','0');
Insert into AD.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('3','1','1','10/12/2014','2','50','N','201412101','0');
Insert into AD.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('1','1','1','09/12/2014','3','50','N','20141291','0');
Insert into AD.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('4','1','1','10/12/2014','3','85','N','201412103','0');
Insert into AD.PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO,ELIMINADO) values ('5','1','1','10/12/2014','3','100','N','201412103','0');
REM INSERTING into AD.PEDIDOSARTICULOS
SET DEFINE OFF;
Insert into AD.PEDIDOSARTICULOS (IDPEDIDOARTICULO,REFPEDIDO,REFARTICULO,CANTIDAD,PRECIOVENTA) values ('1','1','3','1','85');
Insert into AD.PEDIDOSARTICULOS (IDPEDIDOARTICULO,REFPEDIDO,REFARTICULO,CANTIDAD,PRECIOVENTA) values ('2','1','1','1','50');
Insert into AD.PEDIDOSARTICULOS (IDPEDIDOARTICULO,REFPEDIDO,REFARTICULO,CANTIDAD,PRECIOVENTA) values ('3','3','3','1','85');
Insert into AD.PEDIDOSARTICULOS (IDPEDIDOARTICULO,REFPEDIDO,REFARTICULO,CANTIDAD,PRECIOVENTA) values ('4','3','2','1','100');
REM INSERTING into AD.USUARIOS
SET DEFINE OFF;
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('4','Luis','$2a$10$woQp6bc2w3UgMrbSftRImuOUlzV/sX62u9y9eJi.vWpA3S.quJwne','0','2');
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('2','Carlos','$2a$10$JIXWxPhIKHs/Q/P7es/wKuhzk9T7UhP9kubPZEUfDiTNNL0BiWVJ6','1','2');
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('3','Noemi','$2a$10$e2g3pVj6bZhB3XBo4D.WxOJYEcMofMA6fkpwA2uAU43G089Coy0RG','1','3');
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('1','ROOT','$2a$10$o15Ks1bfPYTpWaCvXPqgTOnoxi9wGP9EafD4IyfFB6vGl1Hh4Nq6K','0','1');
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('5','hola','$2a$10$.Bq7z7/YdlZ/YDcnGkQ9summ.vp.j/lOdDLd/sukV79YtE/YVfTpC','0','3');
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('6','usuario','$2a$10$Ucmz7bCpOWT49Kdiiw/A0umgwPkb3Z.TvgWZRdLy1yVUix3QIjb96','0','3');
REM INSERTING into AD.ROLES
SET DEFINE OFF;
Insert into AD.ROLES (IDROL,NOMBREROL) values ('1','ROOT');
Insert into AD.ROLES (IDROL,NOMBREROL) values ('2','ADMINISTRATIVO');
Insert into AD.ROLES (IDROL,NOMBREROL) values ('3','OPERATIVO');
REM INSERTING into AD.HISTORIALCAMBIOS
SET DEFINE OFF;
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('4','5','01/12/2014','2','Usuario modificado');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('1','4','29/11/2014','3','Usuario borrado');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('2','5','29/11/2014','4','Usuario restaurado');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('3','4','29/11/2014','4','Usuario restaurado');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('5','4','01/12/2014','2','Usuario modificado');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('11','1','10/12/2014','1','Pedido a�adido  num_pedido->201412101');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('12','1','10/12/2014','1','Pedido a�adido  num_pedido->201412101');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('13','1','10/12/2014','1','Articulo a�adido ->FUNDA');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('6','0','02/12/2014','1','A�adido nuevo usuario');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('7','6','02/12/2014','2','Usuario modificado');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('8','1','08/12/2014','1','Articulo a�adido ->FOTO');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('10','1','09/12/2014','1','Pedido a�adido  num_pedido->20141291');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('9','1','09/12/2014','1','Pedido a�adido  num_pedido->20141292');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('14','1','10/12/2014','1','Pedido a�adido  num_pedido->201412103');
Insert into AD.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('15','1','10/12/2014','1','Pedido a�adido  num_pedido->201412103');
REM INSERTING into AD.TIPOCAMBIO
SET DEFINE OFF;
Insert into AD.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('1','A�adido');
Insert into AD.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('2','Modificado');
Insert into AD.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('3','Borrado');
Insert into AD.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('4','Restaurar');
REM INSERTING into AD.FORMASDEPAGO
SET DEFINE OFF;
Insert into AD.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('1','TARJETA','1');
Insert into AD.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('2','CONTRAREEMBOLSO','1');
Insert into AD.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('3','PAYPAL','1');
Insert into AD.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('4','EFECTIVO','1');
Insert into AD.FORMASDEPAGO (IDPAGO,FORMAPAGO,ACTIVO) values ('5','TRANSFERENCIA','1');
--------------------------------------------------------
--  DDL for Index ARTICULOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."ARTICULOS_PK" ON "AD"."ARTICULOS" ("IDARTICULO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SYS_C0010010
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."SYS_C0010010" ON "AD"."COMPOSICIONES" ("IDCOMPOSICION") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SYS_C0010011
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."SYS_C0010011" ON "AD"."MEDIDAS" ("IDMEDIDA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PEDIDOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."PEDIDOS_PK" ON "AD"."PEDIDOS" ("IDPEDIDO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PEDIDOSARTICULOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."PEDIDOSARTICULOS_PK" ON "AD"."PEDIDOSARTICULOS" ("IDPEDIDOARTICULO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index USUARIOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."USUARIOS_PK" ON "AD"."USUARIOS" ("IDUSUARIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index ROLES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."ROLES_PK" ON "AD"."ROLES" ("IDROL") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index HISTORIAL_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."HISTORIAL_PK" ON "AD"."HISTORIALCAMBIOS" ("IDHISTOCAMBIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index TIPOCAMBIO_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."TIPOCAMBIO_PK" ON "AD"."TIPOCAMBIO" ("IDTIPOCAMBIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index FORMASDEPAGO_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."FORMASDEPAGO_PK" ON "AD"."FORMASDEPAGO" ("IDPAGO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table ARTICULOS
--------------------------------------------------------

  ALTER TABLE "AD"."ARTICULOS" ADD CONSTRAINT "ARTICULOS_PK" PRIMARY KEY ("IDARTICULO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "AD"."ARTICULOS" MODIFY ("IDARTICULO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table COMPOSICIONES
--------------------------------------------------------

  ALTER TABLE "AD"."COMPOSICIONES" ADD PRIMARY KEY ("IDCOMPOSICION")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table MEDIDAS
--------------------------------------------------------

  ALTER TABLE "AD"."MEDIDAS" ADD PRIMARY KEY ("IDMEDIDA")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table PEDIDOS
--------------------------------------------------------

  ALTER TABLE "AD"."PEDIDOS" ADD CONSTRAINT "PEDIDOS_PK" PRIMARY KEY ("IDPEDIDO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "AD"."PEDIDOS" MODIFY ("IDPEDIDO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PEDIDOSARTICULOS
--------------------------------------------------------

  ALTER TABLE "AD"."PEDIDOSARTICULOS" ADD CONSTRAINT "PEDIDOSARTICULOS_PK" PRIMARY KEY ("IDPEDIDOARTICULO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "AD"."PEDIDOSARTICULOS" MODIFY ("IDPEDIDOARTICULO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table USUARIOS
--------------------------------------------------------

  ALTER TABLE "AD"."USUARIOS" ADD CONSTRAINT "USUARIOS_PK" PRIMARY KEY ("IDUSUARIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "AD"."USUARIOS" MODIFY ("ELIMINADO" NOT NULL ENABLE);
  ALTER TABLE "AD"."USUARIOS" MODIFY ("PASSWORD" NOT NULL ENABLE);
  ALTER TABLE "AD"."USUARIOS" MODIFY ("NOMBRE" NOT NULL ENABLE);
  ALTER TABLE "AD"."USUARIOS" MODIFY ("IDUSUARIO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ROLES
--------------------------------------------------------

  ALTER TABLE "AD"."ROLES" MODIFY ("NOMBREROL" NOT NULL ENABLE);
  ALTER TABLE "AD"."ROLES" MODIFY ("IDROL" NOT NULL ENABLE);
  ALTER TABLE "AD"."ROLES" ADD CONSTRAINT "ROLES_PK" PRIMARY KEY ("IDROL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table HISTORIALCAMBIOS
--------------------------------------------------------

  ALTER TABLE "AD"."HISTORIALCAMBIOS" MODIFY ("IDHISTOCAMBIO" NOT NULL ENABLE);
  ALTER TABLE "AD"."HISTORIALCAMBIOS" MODIFY ("IDUSUARIO" NOT NULL ENABLE);
  ALTER TABLE "AD"."HISTORIALCAMBIOS" MODIFY ("FECHA" NOT NULL ENABLE);
  ALTER TABLE "AD"."HISTORIALCAMBIOS" MODIFY ("IDTIPOCAMBIO" NOT NULL ENABLE);
  ALTER TABLE "AD"."HISTORIALCAMBIOS" MODIFY ("OBSERVACION" NOT NULL ENABLE);
  ALTER TABLE "AD"."HISTORIALCAMBIOS" ADD CONSTRAINT "HISTORIAL_PK" PRIMARY KEY ("IDHISTOCAMBIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table TIPOCAMBIO
--------------------------------------------------------

  ALTER TABLE "AD"."TIPOCAMBIO" ADD CONSTRAINT "TIPOCAMBIO_PK" PRIMARY KEY ("IDTIPOCAMBIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "AD"."TIPOCAMBIO" MODIFY ("IDTIPOCAMBIO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FORMASDEPAGO
--------------------------------------------------------

  ALTER TABLE "AD"."FORMASDEPAGO" ADD CONSTRAINT "FORMASDEPAGO_PK" PRIMARY KEY ("IDPAGO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "AD"."FORMASDEPAGO" MODIFY ("ACTIVO" NOT NULL ENABLE);
  ALTER TABLE "AD"."FORMASDEPAGO" MODIFY ("FORMAPAGO" NOT NULL ENABLE);
  ALTER TABLE "AD"."FORMASDEPAGO" MODIFY ("IDPAGO" NOT NULL ENABLE);
--------------------------------------------------------
--  Ref Constraints for Table PEDIDOS
--------------------------------------------------------

  ALTER TABLE "AD"."PEDIDOS" ADD CONSTRAINT "PEDIDOS_FK1" FOREIGN KEY ("REFUSUARIO")
	  REFERENCES "AD"."USUARIOS" ("IDUSUARIO") ENABLE;
  ALTER TABLE "AD"."PEDIDOS" ADD CONSTRAINT "PEDIDOS_FPAGO" FOREIGN KEY ("REFFORMAPAGO")
	  REFERENCES "AD"."FORMASDEPAGO" ("IDPAGO") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table PEDIDOSARTICULOS
--------------------------------------------------------

  ALTER TABLE "AD"."PEDIDOSARTICULOS" ADD CONSTRAINT "PEDIDOSARTICULOS_ARTICULO" FOREIGN KEY ("REFARTICULO")
	  REFERENCES "AD"."ARTICULOS" ("IDARTICULO") ENABLE;
  ALTER TABLE "AD"."PEDIDOSARTICULOS" ADD CONSTRAINT "PEDIDOSARTICULOS_PEDIDO" FOREIGN KEY ("REFPEDIDO")
	  REFERENCES "AD"."PEDIDOS" ("IDPEDIDO") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table HISTORIALCAMBIOS
--------------------------------------------------------

  ALTER TABLE "AD"."HISTORIALCAMBIOS" ADD CONSTRAINT "HISTORIALCAMBIOS_FK1" FOREIGN KEY ("IDHISTOCAMBIO")
	  REFERENCES "AD"."HISTORIALCAMBIOS" ("IDHISTOCAMBIO") ENABLE;
