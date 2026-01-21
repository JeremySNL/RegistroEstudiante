CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "Estudiantes" (
    "EstudianteId" INTEGER NOT NULL CONSTRAINT "PK_Estudiantes" PRIMARY KEY AUTOINCREMENT,
    "Nombres" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Edad" INTEGER NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260119192532_Inicial', '10.0.2');

COMMIT;

