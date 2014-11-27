--------------------------------------------------------
-- Archivo creado  - jueves-noviembre-27-2014   
--------------------------------------------------------
DROP TABLE "AD"."USUARIOS" cascade constraints;
DROP TABLE "AD"."ROLES" cascade constraints;
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
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "AD"."USUARIOS"."IDUSUARIO" IS 'IDENTIFICADOR DEL USUARIO
';
 
   COMMENT ON COLUMN "AD"."USUARIOS"."NOMBRE" IS 'NOMBRE DEL USUARIO';
 
   COMMENT ON COLUMN "AD"."USUARIOS"."PASSWORD" IS 'CONTRASEŅA DE ACCESO';
 
   COMMENT ON COLUMN "AD"."USUARIOS"."ELIMINADO" IS '0 -> NO ELIMINADO 1-> ELIMINADO';
 
   COMMENT ON COLUMN "AD"."USUARIOS"."IDROL" IS 'PERMISOS DEL USUARIO';
--------------------------------------------------------
--  DDL for Table ROLES
--------------------------------------------------------

  CREATE TABLE "AD"."ROLES" 
   (	"IDROL" NUMBER(1,0), 
	"NOMBREROL" VARCHAR2(30 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "AD"."ROLES"."IDROL" IS 'IDENTIFICADOR DEL ROL';
REM INSERTING into AD.USUARIOS
SET DEFINE OFF;
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('4','Luis','$2a$10$Dg4/aLcoINVyl7q.GEaxIOx.1SgwI4WaU/rXwdqRmbh7V0smWD7Um','0','2');
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('2','Carlos','$2a$10$JIXWxPhIKHs/Q/P7es/wKuhzk9T7UhP9kubPZEUfDiTNNL0BiWVJ6','1','2');
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('3','Noemi','$2a$10$e2g3pVj6bZhB3XBo4D.WxOJYEcMofMA6fkpwA2uAU43G089Coy0RG','1','3');
Insert into AD.USUARIOS (IDUSUARIO,NOMBRE,PASSWORD,ELIMINADO,IDROL) values ('1','ROOT','$2a$10$o15Ks1bfPYTpWaCvXPqgTOnoxi9wGP9EafD4IyfFB6vGl1Hh4Nq6K','0','1');
--------------------------------------------------------
--  DDL for Index USUARIOS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "AD"."USUARIOS_PK" ON "AD"."USUARIOS" ("IDUSUARIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table USUARIOS
--------------------------------------------------------

  ALTER TABLE "AD"."USUARIOS" MODIFY ("IDUSUARIO" NOT NULL ENABLE);
 
  ALTER TABLE "AD"."USUARIOS" MODIFY ("NOMBRE" NOT NULL ENABLE);
 
  ALTER TABLE "AD"."USUARIOS" MODIFY ("PASSWORD" NOT NULL ENABLE);
 
  ALTER TABLE "AD"."USUARIOS" MODIFY ("ELIMINADO" NOT NULL ENABLE);
 
  ALTER TABLE "AD"."USUARIOS" ADD CONSTRAINT "USUARIOS_PK" PRIMARY KEY ("IDUSUARIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table USUARIOS
--------------------------------------------------------

  ALTER TABLE "AD"."USUARIOS" ADD CONSTRAINT "USUARIOS_FKROL" FOREIGN KEY ("IDROL")
	  REFERENCES "AD"."ROLES" ("IDROL") ENABLE;
