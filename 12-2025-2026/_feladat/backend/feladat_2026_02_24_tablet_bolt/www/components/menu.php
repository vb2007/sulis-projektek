<nav class="bg-teal-700">
    <div class="mx-auto max-w-7xl px-4">
        <div class="flex h-16 items-center justify-between">
            <a href="index.php" class="text-xl font-bold text-white">
                Tabletek
            </a>
            <button class="md:hidden text-teal-100 hover:text-white"
                onclick="document.getElementById('nav-menu').classList.toggle('hidden')">
                ☰
            </button>
            <ul id="nav-menu" class="hidden md:flex md:items-center md:space-x-2
                       absolute md:static top-16 left-0 w-full md:w-auto
                       bg-teal-800 md:bg-transparent
                       px-4 md:px-0 py-3 md:py-0">
                <?php foreach ($menuItems as $item): ?>
                    <li>
                        <a href="<?= $item['url'] ?>" class="block py-2 px-2 text-sm font-medium transition <?= $item['active'] ? 'text-white md:border-b-2 md:border-teal-300' : 'text-teal-100 hover:text-white' ?>">
                            <?= $item['text'] ?>
                        </a>
                    </li>
                <?php endforeach; ?>
            </ul>
        </div>
    </div>
</nav>
