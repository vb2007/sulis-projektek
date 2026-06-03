<nav class="py-4 px-8 bg-lime-800 text-white flex gap-4">
    <a href="index.php" class="font-bold flex-1">OfficeRent</a>
    <ul class="flex gap-4">
        <?php foreach ($menuItems as $menuItem): ?>
            <li class="<?= $menuItem["active"] ? "text-white md:border-b-2 md:border-lime-300" : "text-lime-50 hover:text-white" ?>">
                <a href="<?= $menuItem["url"] ?>">
                    <?= $menuItem["text"] ?>
                </a>
            </li>
        <?php endforeach; ?>
    </ul>
</nav>
