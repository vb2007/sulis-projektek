<?php
$menuItems = [
    "table" => "Táblázat",
    "grid" => "Rács",
]; ?>

<nav class="bg-blue-600 text-white py-2 px-4 flex justify-between mb-4 text-lg">
    <span>Objektívek</span>
    <ul class="flex items-center gap-4 ">
        <?php foreach ($menuItems as $key => $value): ?>
            <li class="nav-item">
                <a class="nav-link <?= $page == $key
                    ? "font-bold"
                    : "" ?>" href="index.php?page=<?= $key ?>"><?= $value ?></a>
            </li>
        <?php endforeach; ?>
    </ul>
</nav>
