-- ============================================================
-- Projet      : MediaTek86 - Gestion du personnel
-- Date        : 2025-2026
-- Description : Script de création de la base de données
-- Import      : Dans phpMyAdmin, sélectionner "Importer",
--               choisir ce fichier .sql, puis cliquer sur
--               "Exécuter". Aucune base de données ne doit
--               être sélectionnée avant l'import.
-- ============================================================

DROP DATABASE IF EXISTS bdmediatek86;
CREATE DATABASE bdmediatek86 CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE bdmediatek86;

CREATE TABLE service(
   idservice INT AUTO_INCREMENT,
   nom VARCHAR(50) ,
   PRIMARY KEY(idservice)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE motif(
   idmotif INT AUTO_INCREMENT,
   libelle VARCHAR(128) ,
   PRIMARY KEY(idmotif)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE personnel(
   idpersonnel INT AUTO_INCREMENT,
   nom VARCHAR(50) ,
   prenom VARCHAR(50) ,
   tel VARCHAR(15) ,
   mail VARCHAR(128) ,
   idservice INT NOT NULL,
   PRIMARY KEY(idpersonnel),
   FOREIGN KEY(idservice) REFERENCES service(idservice)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE absence(
   idpersonnel INT,
   datedebut DATETIME,
   datefin DATETIME,
   idmotif INT NOT NULL,
   PRIMARY KEY(idpersonnel, datedebut),
   FOREIGN KEY(idpersonnel) REFERENCES personnel(idpersonnel),
   FOREIGN KEY(idmotif) REFERENCES motif(idmotif)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE responsable(
   login VARCHAR(64) NOT NULL,
   pwd VARCHAR(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- Données initiales
-- ============================================================

INSERT INTO service (nom) VALUES
   ('administratif'),
   ('médiation culturelle'),
   ('prêt');

INSERT INTO motif (libelle) VALUES
   ('vacances'),
   ('maladie'),
   ('motif familial'),
   ('congé parental');

INSERT INTO responsable (login, pwd) VALUES ('admin', SHA2('admin', 256));

-- ============================================================
-- Requêtes de vérification
-- ============================================================

-- SELECT COUNT(*) FROM service;
-- SELECT COUNT(*) FROM motif;
-- SELECT COUNT(*) FROM responsable;
-- SELECT * FROM responsable;
