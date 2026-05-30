-- ============================================================
-- Projet      : MediaTek86 - Gestion du personnel
-- Description : Script complet de déploiement de la BDD
--               (CREATE DATABASE + CREATE TABLE + INSERT + utilisateur applicatif)
-- Date        : 2026
-- Instructions d'import :
--   Dans phpMyAdmin, sélectionner "Importer", choisir ce fichier .sql,
--   puis cliquer sur "Exécuter".
--   Aucune base ne doit être sélectionnée avant l'import.
-- ============================================================

-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : sam. 30 mai 2026 à 13:56
-- Version du serveur : 8.4.7
-- Version de PHP : 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

-- ============================================================
-- Structure de la base de données
-- ============================================================

--
-- Création de la base de données
--
CREATE DATABASE IF NOT EXISTS `bdmediatek86`
  DEFAULT CHARACTER SET utf8mb4
  DEFAULT COLLATE utf8mb4_0900_ai_ci;
USE `bdmediatek86`;

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int NOT NULL,
  `datedebut` datetime NOT NULL,
  `datefin` datetime DEFAULT NULL,
  `idmotif` int NOT NULL,
  PRIMARY KEY (`idpersonnel`,`datedebut`),
  KEY `idmotif` (`idmotif`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(1, '2024-01-15 00:00:00', '2024-01-22 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(1, '2024-03-04 00:00:00', '2024-03-06 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(1, '2024-07-22 00:00:00', '2024-08-12 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(1, '2024-11-18 00:00:00', '2024-11-20 00:00:00', 3);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(1, '2025-02-10 00:00:00', '2025-02-14 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(2, '2024-02-05 00:00:00', '2024-02-09 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(2, '2024-05-13 00:00:00', '2024-05-17 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(2, '2024-09-02 00:00:00', '2024-09-13 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(2, '2025-01-06 00:00:00', '2025-01-08 00:00:00', 3);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(2, '2025-04-21 00:00:00', '2025-04-25 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(3, '2024-01-29 00:00:00', '2024-02-02 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(3, '2024-06-10 00:00:00', '2024-06-14 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(3, '2024-10-07 00:00:00', '2024-10-25 00:00:00', 4);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(3, '2025-03-17 00:00:00', '2025-03-19 00:00:00', 3);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(3, '2025-07-14 00:00:00', '2025-08-01 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(4, '2024-02-19 00:00:00', '2024-02-23 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(4, '2024-05-27 00:00:00', '2024-05-31 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(4, '2024-09-16 00:00:00', '2024-09-20 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(4, '2025-02-24 00:00:00', '2025-02-28 00:00:00', 3);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(4, '2025-06-09 00:00:00', '2025-06-13 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(5, '2024-03-11 00:00:00', '2024-03-15 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(5, '2024-08-05 00:00:00', '2024-08-16 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(5, '2024-12-23 00:00:00', '2024-12-27 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(5, '2025-04-07 00:00:00', '2025-04-11 00:00:00', 3);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(5, '2025-09-22 00:00:00', '2025-09-26 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(6, '2024-04-08 00:00:00', '2024-04-12 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(6, '2024-07-15 00:00:00', '2024-07-26 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(6, '2024-11-04 00:00:00', '2024-11-08 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(6, '2025-03-03 00:00:00', '2025-03-07 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(6, '2025-08-18 00:00:00', '2025-08-29 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(7, '2024-02-26 00:00:00', '2024-03-01 00:00:00', 3);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(7, '2024-06-17 00:00:00', '2024-06-21 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(7, '2024-10-14 00:00:00', '2024-10-18 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(7, '2025-05-12 00:00:00', '2025-05-16 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(7, '2025-10-06 00:00:00', '2025-10-10 00:00:00', 4);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(8, '2024-01-08 00:00:00', '2024-01-12 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(8, '2024-04-22 00:00:00', '2024-04-26 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(8, '2024-08-26 00:00:00', '2024-09-06 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(8, '2025-01-20 00:00:00', '2025-01-24 00:00:00', 3);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(8, '2025-06-23 00:00:00', '2025-07-04 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(9, '2024-03-25 00:00:00', '2024-03-29 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(9, '2024-07-01 00:00:00', '2024-07-12 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(9, '2024-11-25 00:00:00', '2024-11-29 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(9, '2025-04-14 00:00:00', '2025-04-18 00:00:00', 3);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(9, '2025-09-08 00:00:00', '2025-09-19 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(10, '2024-05-06 00:00:00', '2024-05-10 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(10, '2024-09-23 00:00:00', '2024-09-27 00:00:00', 2);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(10, '2024-12-09 00:00:00', '2024-12-13 00:00:00', 3);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(10, '2025-05-19 00:00:00', '2025-05-30 00:00:00', 1);
INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES(10, '2025-10-13 00:00:00', '2025-10-17 00:00:00', 4);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES(1, 'vacances');
INSERT INTO `motif` (`idmotif`, `libelle`) VALUES(2, 'maladie');
INSERT INTO `motif` (`idmotif`, `libelle`) VALUES(3, 'motif familial');
INSERT INTO `motif` (`idmotif`, `libelle`) VALUES(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `tel` varchar(15) DEFAULT NULL,
  `mail` varchar(128) DEFAULT NULL,
  `idservice` int NOT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `idservice` (`idservice`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(1, 'Flores', 'Anthony', '0612345001', 'anthony.flores@yahoo.fr', 1);
INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(2, 'Kemp', 'Aspen', '0612345002', 'aspen.kemp@aol.fr', 2);
INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(3, 'Giles', 'Keaton', '0612345003', 'keaton.giles@google.fr', 1);
INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(4, 'Burris', 'Lila', '0612345004', 'lila.burris@google.fr', 2);
INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(5, 'Crawford', 'Ethan', '0612345005', 'ethan.crawford@google.fr', 3);
INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(6, 'Dominguez', 'Fallon', '0612345006', 'fallon.dominguez@aol.fr', 3);
INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(7, 'Cummings', 'Claudia', '0612345007', 'claudia.cummings@aol.fr', 3);
INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(8, 'Herman', 'Halla', '0612345008', 'halla.herman@hotmail.fr', 1);
INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(9, 'Haney', 'Burke', '0612345009', 'burke.haney@protonmail.fr', 1);
INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES(10, 'Rutledge', 'Reece', '0612345010', 'reece.rutledge@yahoo.fr', 2);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) NOT NULL,
  `pwd` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES(1, 'administratif');
INSERT INTO `service` (`idservice`, `nom`) VALUES(2, 'médiation culturelle');
INSERT INTO `service` (`idservice`, `nom`) VALUES(3, 'prêt');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `absence`
--
ALTER TABLE `absence`
  ADD CONSTRAINT `absence_ibfk_1` FOREIGN KEY (`idpersonnel`) REFERENCES `personnel` (`idpersonnel`),
  ADD CONSTRAINT `absence_ibfk_2` FOREIGN KEY (`idmotif`) REFERENCES `motif` (`idmotif`);

--
-- Contraintes pour la table `personnel`
--
ALTER TABLE `personnel`
  ADD CONSTRAINT `personnel_ibfk_1` FOREIGN KEY (`idservice`) REFERENCES `service` (`idservice`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

-- ============================================================
-- Création de l'utilisateur applicatif
-- ============================================================
-- Suppression de l'utilisateur s'il existe déjà (pour permettre la réinstallation)
DROP USER IF EXISTS 'adminmediatek'@'localhost';
-- Création de l'utilisateur avec authentification mysql_native_password (compatibilité MySQL 8 + .NET Connector)
CREATE USER 'adminmediatek'@'localhost' IDENTIFIED WITH mysql_native_password BY 'mediatek86';
-- Attribution des droits sur la base bdmediatek86 uniquement
GRANT ALL PRIVILEGES ON bdmediatek86.* TO 'adminmediatek'@'localhost';
FLUSH PRIVILEGES;
