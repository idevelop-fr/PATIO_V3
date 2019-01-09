-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Ven 09 Novembre 2018 à 08:48
-- Version du serveur :  5.7.11
-- Version de PHP :  7.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `patio`
--

-- --------------------------------------------------------

--
-- Structure de la table `lien`
--

DROP TABLE IF EXISTS `lien`;
CREATE TABLE `lien` (
  `id` int(11) NOT NULL,
  `Element0_Type` int(11) NOT NULL,
  `Element0_Code` varchar(100) COLLATE latin1_general_ci DEFAULT NULL,
  `Element0_ID` int(11) NOT NULL,
  `Element1_Type` int(11) NOT NULL,
  `Element1_Code` varchar(100) COLLATE latin1_general_ci DEFAULT NULL,
  `Element1_ID` int(11) NOT NULL,
  `Element2_Type` int(11) NOT NULL,
  `Element2_Code` varchar(100) COLLATE latin1_general_ci DEFAULT NULL,
  `Element2_ID` int(11) NOT NULL,
  `ordre` smallint(6) NOT NULL,
  `complement` varchar(100) COLLATE latin1_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Index pour les tables exportées
--

--
-- Index pour la table `lien`
--
ALTER TABLE `lien`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Element0_Type` (`Element0_Type`),
  ADD KEY `id` (`id`),
  ADD KEY `Element0_ID` (`Element0_ID`),
  ADD KEY `Element0_Code` (`Element0_Code`),
  ADD KEY `Element1_Code` (`Element1_Code`),
  ADD KEY `Element1_Type` (`Element1_Type`),
  ADD KEY `Element1_ID` (`Element1_ID`),
  ADD KEY `Element2_Type` (`Element2_Type`),
  ADD KEY `Element2_Code` (`Element2_Code`),
  ADD KEY `ordre` (`ordre`),
  ADD KEY `Element2_ID` (`Element2_ID`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `lien`
--
ALTER TABLE `lien`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
