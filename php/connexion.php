<?php
// D�claration des param�tres de connexion
$host = "p:"."localhost";
$user = "root";
$passwd  = "root";
$bdd = "patio";

// Connexion au serveur
$link = mysqli_connect($host, $user,$passwd, $bdd) or die("Erreur de connexion au serveur");

if (mysqli_connect_errno()) {
    printf("�chec de la connexion : %s\n", mysqli_connect_error());
    exit();
}	
?>
