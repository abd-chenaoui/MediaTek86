-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mer. 03 juin 2026 à 07:06
-- Version du serveur : 8.4.7
-- Version de PHP : 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `mediatek86`
--

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `datedebut` datetime NOT NULL,
  `datefin` datetime DEFAULT NULL,
  `idpersonnel` int NOT NULL,
  `idmotif` int DEFAULT NULL,
  PRIMARY KEY (`datedebut`,`idpersonnel`),
  KEY `idpersonnel` (`idpersonnel`),
  KEY `idmotif` (`idmotif`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`datedebut`, `datefin`, `idpersonnel`, `idmotif`) VALUES
('2025-01-06 00:00:00', '2025-01-10 00:00:00', 1, 1),
('2025-01-13 00:00:00', '2025-01-14 00:00:00', 2, 2),
('2025-01-20 00:00:00', '2025-01-24 00:00:00', 3, 3),
('2025-02-03 00:00:00', '2025-02-07 00:00:00', 4, 1),
('2025-02-10 00:00:00', '2025-02-11 00:00:00', 5, 2),
('2025-02-17 00:00:00', '2025-02-21 00:00:00', 6, 4),
('2025-02-24 00:00:00', '2025-02-25 00:00:00', 7, 3),
('2025-03-03 00:00:00', '2025-03-07 00:00:00', 8, 1),
('2025-03-10 00:00:00', '2025-03-12 00:00:00', 9, 2),
('2025-03-17 00:00:00', '2025-03-21 00:00:00', 10, 1),
('2025-03-24 00:00:00', '2025-03-28 00:00:00', 1, 4),
('2025-04-01 00:00:00', '2025-04-04 00:00:00', 2, 3),
('2025-04-07 00:00:00', '2025-04-11 00:00:00', 3, 1),
('2025-04-14 00:00:00', '2025-04-15 00:00:00', 4, 2),
('2025-04-22 00:00:00', '2025-04-25 00:00:00', 5, 1),
('2025-04-28 00:00:00', '2025-04-30 00:00:00', 6, 3),
('2025-05-05 00:00:00', '2025-05-09 00:00:00', 7, 2),
('2025-05-12 00:00:00', '2025-05-16 00:00:00', 8, 4),
('2025-05-19 00:00:00', '2025-05-20 00:00:00', 9, 1),
('2025-05-26 00:00:00', '2025-05-30 00:00:00', 10, 3),
('2025-06-02 00:00:00', '2025-06-06 00:00:00', 1, 2),
('2025-06-09 00:00:00', '2025-06-13 00:00:00', 2, 1),
('2025-06-16 00:00:00', '2025-06-17 00:00:00', 3, 4),
('2025-06-23 00:00:00', '2025-06-27 00:00:00', 4, 2),
('2025-06-30 00:00:00', '2025-07-04 00:00:00', 5, 1),
('2025-07-07 00:00:00', '2025-07-11 00:00:00', 6, 1),
('2025-07-14 00:00:00', '2025-07-15 00:00:00', 7, 3),
('2025-07-21 00:00:00', '2025-07-25 00:00:00', 8, 2),
('2025-07-28 00:00:00', '2025-08-01 00:00:00', 9, 4),
('2025-08-04 00:00:00', '2025-08-08 00:00:00', 10, 1),
('2025-08-11 00:00:00', '2025-08-15 00:00:00', 1, 3),
('2025-08-18 00:00:00', '2025-08-19 00:00:00', 2, 2),
('2025-08-25 00:00:00', '2025-08-29 00:00:00', 3, 1),
('2025-09-01 00:00:00', '2025-09-05 00:00:00', 4, 4),
('2025-09-08 00:00:00', '2025-09-09 00:00:00', 5, 2),
('2025-09-15 00:00:00', '2025-09-19 00:00:00', 6, 1),
('2025-09-22 00:00:00', '2025-09-26 00:00:00', 7, 3),
('2025-09-29 00:00:00', '2025-10-03 00:00:00', 8, 2),
('2025-10-06 00:00:00', '2025-10-10 00:00:00', 9, 1),
('2025-10-13 00:00:00', '2025-10-14 00:00:00', 10, 4),
('2025-10-20 00:00:00', '2025-10-24 00:00:00', 1, 2),
('2025-10-27 00:00:00', '2025-10-31 00:00:00', 2, 3),
('2025-11-03 00:00:00', '2025-11-07 00:00:00', 3, 1),
('2025-11-10 00:00:00', '2025-11-11 00:00:00', 4, 2),
('2025-11-17 00:00:00', '2025-11-21 00:00:00', 5, 4),
('2025-11-24 00:00:00', '2025-11-28 00:00:00', 6, 1),
('2025-12-01 00:00:00', '2025-12-05 00:00:00', 7, 2),
('2025-12-08 00:00:00', '2025-12-09 00:00:00', 8, 3),
('2025-12-15 00:00:00', '2025-12-19 00:00:00', 9, 1),
('2025-12-22 00:00:00', '2025-12-24 00:00:00', 10, 2);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `mytable`
--

DROP TABLE IF EXISTS `mytable`;
CREATE TABLE IF NOT EXISTS `mytable` (
  `id` mediumint UNSIGNED NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `prenom` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tel` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mail` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `idservice` mediumint DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `mytable`
--

INSERT INTO `mytable` (`id`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(1, 'Fulton', 'Carson', '06 94 92 68 57', 'non.leo@yahoo.org', 1),
(2, 'Cohen', 'Adam', '04 02 17 58 38', 'velit@yahoo.ca', 2),
(3, 'Britt', 'Quinn', '05 64 28 59 85', 'placerat@outlook.ca', 1),
(4, 'Nicholson', 'Justin', '06 18 09 13 56', 'non.sapien@protonmail.edu', 2),
(5, 'Maxwell', 'Barrett', '06 74 12 56 47', 'pretium.aliquet@outlook.couk', 2),
(6, 'Everett', 'Upton', '08 81 35 82 26', 'donec.nibh.quisque@google.couk', 1),
(7, 'Case', 'Brett', '03 56 22 35 23', 'phasellus.in.felis@google.org', 1),
(8, 'Conner', 'Wade', '07 17 53 54 84', 'erat@icloud.ca', 1),
(9, 'Montoya', 'Talon', '07 70 82 81 83', 'curabitur@outlook.couk', 1),
(10, 'Cherry', 'Austin', '01 99 19 37 43', 'eget@yahoo.edu', 2);

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `prenom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tel` varchar(15) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mail` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `idservice` int DEFAULT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `idservice` (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(1, 'Fulton', 'Carson', '06 94 92 68 57', 'non.leo@yahoo.org', 1),
(2, 'Cohen', 'Adam', '04 02 17 58 38', 'velit@yahoo.ca', 2),
(3, 'Britt', 'Quinn', '05 64 28 59 85', 'placerat@outlook.ca', 1),
(4, 'Nicholson', 'Justin', '06 18 09 13 56', 'non.sapien@protonmail.com', 2),
(5, 'Maxwell', 'Barrett', '06 74 12 56 47', 'pretium.aliquet@outlook.com', 2),
(6, 'Everett', 'Upton', '08 81 35 82 26', 'donec.nibh@google.com', 3),
(7, 'Case', 'Brett', '03 56 22 35 23', 'phasellus.felis@google.org', 1),
(8, 'Conner', 'Wade', '07 17 53 54 84', 'erat@icloud.ca', 3),
(9, 'Montoya', 'Talon', '07 70 82 81 83', 'curabitur@outlook.com', 2),
(10, 'Cherry', 'Austin', '01 99 19 37 43', 'eget@yahoo.com', 3);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `pwd` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('admin', '967520ae23e8ee14888bae72809031b98398ae4a636773e18fff917d77679334'),
('admin', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'),
('admin', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
