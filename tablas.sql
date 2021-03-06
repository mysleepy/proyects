--------------------------------------------------------
-- Archivo creado  - lunes-diciembre-08-2014   
--------------------------------------------------------
DROP TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" cascade constraints;
DROP TABLE "C##EJEMPLO1"."TIPOCAMBIO" cascade constraints;
DROP TABLE "C##EJEMPLO1"."PROVEEDORES" cascade constraints;
DROP TABLE "C##EJEMPLO1"."PROVEEDORARTICULOS" cascade constraints;
--------------------------------------------------------
--  DDL for Table HISTORIALCAMBIOS
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" 
   (	"IDHISTOCAMBIO" NUMBER(4,0), 
	"IDUSUARIO" NUMBER(3,0), 
	"FECHA" VARCHAR2(20 BYTE), 
	"IDTIPOCAMBIO" NUMBER(4,0), 
	"OBSERVACION" VARCHAR2(150 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table TIPOCAMBIO
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."TIPOCAMBIO" 
   (	"IDTIPOCAMBIO" NUMBER(4,0), 
	"DESCRIPCION" VARCHAR2(40 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table PROVEEDORES
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."PROVEEDORES" 
   (	"IDPROVEEDOR" NUMBER(5,0), 
	"CIF" VARCHAR2(9 BYTE), 
	"NOMBRE" VARCHAR2(30 BYTE), 
	"APELLIDO" VARCHAR2(20 BYTE), 
	"DIRECCION" VARCHAR2(30 BYTE), 
	"REFCPPOBLACIONES" NUMBER(5,0), 
	"TELEFONO" NUMBER(9,0), 
	"EMAIL" VARCHAR2(30 BYTE), 
	"ELIMINADO" NUMBER(1,0)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table PROVEEDORARTICULOS
--------------------------------------------------------

  CREATE TABLE "C##EJEMPLO1"."PROVEEDORARTICULOS" 
   (	"IDPROVART" NUMBER(5,0), 
	"REFPROVEEDOR" NUMBER(5,0), 
	"REFARTICULO" NUMBER(5,0)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
REM INSERTING into C##EJEMPLO1.HISTORIALCAMBIOS
SET DEFINE OFF;
Insert into C##EJEMPLO1.HISTORIALCAMBIOS (IDHISTOCAMBIO,IDUSUARIO,FECHA,IDTIPOCAMBIO,OBSERVACION) values ('1','5','04/12/2014','2','Usuario modificado ->operarioUno');
REM INSERTING into C##EJEMPLO1.TIPOCAMBIO
SET DEFINE OFF;
Insert into C##EJEMPLO1.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('1','A�adido');
Insert into C##EJEMPLO1.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('2','Modificado');
Insert into C##EJEMPLO1.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('3','Borrado');
Insert into C##EJEMPLO1.TIPOCAMBIO (IDTIPOCAMBIO,DESCRIPCION) values ('4','Restaurar');
REM INSERTING into C##EJEMPLO1.PROVEEDORES
SET DEFINE OFF;
REM INSERTING into C##EJEMPLO1.PROVEEDORARTICULOS
SET DEFINE OFF;
--------------------------------------------------------
--  DDL for Index HISTORIAL_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."HISTORIAL_PK" ON "C##EJEMPLO1"."HISTORIALCAMBIOS" ("IDHISTOCAMBIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index TIPOCAMBIO_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."TIPOCAMBIO_PK" ON "C##EJEMPLO1"."TIPOCAMBIO" ("IDTIPOCAMBIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PROVEEDORES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."PROVEEDORES_PK" ON "C##EJEMPLO1"."PROVEEDORES" ("IDPROVEEDOR") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PROVEEDORARTICULOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##EJEMPLO1"."PROVEEDORARTICULOS_PK" ON "C##EJEMPLO1"."PROVEEDORARTICULOS" ("IDPROVART") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table HISTORIALCAMBIOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" ADD CONSTRAINT "HISTORIAL_PK" PRIMARY KEY ("IDHISTOCAMBIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("OBSERVACION" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("IDTIPOCAMBIO" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("FECHA" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("IDUSUARIO" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" MODIFY ("IDHISTOCAMBIO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TIPOCAMBIO
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."TIPOCAMBIO" MODIFY ("IDTIPOCAMBIO" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."TIPOCAMBIO" ADD CONSTRAINT "TIPOCAMBIO_PK" PRIMARY KEY ("IDTIPOCAMBIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table PROVEEDORES
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."PROVEEDORES" ADD CONSTRAINT "PROVEEDORES_PK" PRIMARY KEY ("IDPROVEEDOR")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS NOCOMPRESS LOGGING
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "C##EJEMPLO1"."PROVEEDORES" MODIFY ("ELIMINADO" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."PROVEEDORES" MODIFY ("REFCPPOBLACIONES" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."PROVEEDORES" MODIFY ("DIRECCION" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."PROVEEDORES" MODIFY ("NOMBRE" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."PROVEEDORES" MODIFY ("CIF" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."PROVEEDORES" MODIFY ("IDPROVEEDOR" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PROVEEDORARTICULOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."PROVEEDORARTICULOS" ADD CONSTRAINT "PROVEEDORARTICULOS_PK" PRIMARY KEY ("IDPROVART")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS NOCOMPRESS LOGGING
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "C##EJEMPLO1"."PROVEEDORARTICULOS" MODIFY ("REFARTICULO" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."PROVEEDORARTICULOS" MODIFY ("REFPROVEEDOR" NOT NULL ENABLE);
 
  ALTER TABLE "C##EJEMPLO1"."PROVEEDORARTICULOS" MODIFY ("IDPROVART" NOT NULL ENABLE);
--------------------------------------------------------
--  Ref Constraints for Table HISTORIALCAMBIOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."HISTORIALCAMBIOS" ADD CONSTRAINT "HISTORIALCAMBIOS_FK1" FOREIGN KEY ("IDHISTOCAMBIO")
	  REFERENCES "C##EJEMPLO1"."HISTORIALCAMBIOS" ("IDHISTOCAMBIO") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table PROVEEDORARTICULOS
--------------------------------------------------------

  ALTER TABLE "C##EJEMPLO1"."PROVEEDORARTICULOS" ADD CONSTRAINT "PROVEEDORARTICULOS_FK2" FOREIGN KEY ("REFPROVEEDOR")
	  REFERENCES "C##EJEMPLO1"."PROVEEDORES" ("IDPROVEEDOR") ENABLE;
