<?php
$menuItems = [
    "table" => "Táblázat",
    "grid" => "Rács",
]; ?>
<nav class="bg-gray-50 rounded-lg border border-gray-500 py-2 px-3 flex justify-between">
    <span>Viszonylatok</span>
    <ul class="flex items-center gap-4 ">
        <?php foreach ($menuItems as $key => $value): ?>
            <li>
                <a class="<?= $page === $key
                    ? "font-bold"
                    : "" ?>" href="index.php?page=<?= $key ?>"><?= $value ?></a>
            </li>
        <?php endforeach; ?>
    </ul>
</nav>
