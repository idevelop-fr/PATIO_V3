-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Ven 09 Novembre 2018 à 08:49
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
-- Structure de la table `table_valeur`
--

DROP TABLE IF EXISTS `table_valeur`;
CREATE TABLE `table_valeur` (
  `id` int(11) NOT NULL,
  `nom` varchar(30) COLLATE latin1_general_ci NOT NULL,
  `code` varchar(100) COLLATE latin1_general_ci NOT NULL,
  `valeur` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `valeur_6po` varchar(250) COLLATE latin1_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Index pour les tables exportées
--

--
-- Index pour la table `table_valeur`
--
ALTER TABLE `table_valeur`
  ADD PRIMARY KEY (`id`),
  ADD KEY `type` (`nom`),
  ADD KEY `valeur_6po` (`valeur_6po`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `table_valeur`
--
ALTER TABLE `table_valeur`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
