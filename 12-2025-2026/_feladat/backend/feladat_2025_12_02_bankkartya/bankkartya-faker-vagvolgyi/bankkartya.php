<?php
require __DIR__ . "/vendor/autoload.php";

use Faker\Factory;

$faker = Factory::create("hu_HU");

$cardType = $faker->creditCardType();
$cardNumber = $faker->creditCardNumber($cardType);
$formattedCardNumber = implode('-', str_split($cardNumber, 4));
$expirationDate = $faker->creditCardExpirationDateString();
$ccv = $faker->numerify('###');
$cardholderName = $faker->lastName() . ' ' . $faker->firstName();

echo "Kártya típusa: $cardType\n";
echo "Kártyaszám: $formattedCardNumber\n";
echo "Kártya lejárati ideje (hó/év): $expirationDate\n";
echo "CCV: $ccv\n";
echo "Név: $cardholderName\n";
