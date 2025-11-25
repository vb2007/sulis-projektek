<?php

require "src/Acme/Math.php";
require "src/Acme/Math/Geometry/Circle.php";
require "src/Acme/Graphics/Shapes/Circle.php";

use Acme\Math;
use Acme\Math\Geometry\Circle;
use Acme\Graphics\Shapes\Circle as ShapesCircle;

$math1 = new Math(6, 7);
echo $math1->sum() . PHP_EOL;
$math2 = new Math(4, 1);
echo $math2->sub() . PHP_EOL;

echo "----------------" . PHP_EOL;

$circle1 = new Circle(4);
echo $circle1->circumference() . PHP_EOL;
echo $circle1->area() . PHP_EOL;

echo "----------------" . PHP_EOL;

$circle2 = new ShapesCircle(3, 5, 10);
$position = $circle2->position();
echo "($position[0] ; $position[1])" . PHP_EOL;
echo "1. size: " . $circle2->getSize() . PHP_EOL;
$circle2->setSize(20);
echo "2. size: " . $circle2->getSize() . PHP_EOL;
$circle2->setSize(-5);
echo "3. size: " . $circle2->getSize() . PHP_EOL;
