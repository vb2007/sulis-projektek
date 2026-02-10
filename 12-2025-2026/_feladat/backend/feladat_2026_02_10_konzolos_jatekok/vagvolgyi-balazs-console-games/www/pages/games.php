<?php
require_once __DIR__ . '/../data.php';
?>

<main class="mx-auto max-w-7xl px-4 py-6">
    <h1 class="mb-6 text-4xl font-bold text-center"><?= $title ?></h1>

    <section id="games" class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
        <?php foreach ($games as $game): ?>
            <div class="grid grid-rows-[auto_1fr_auto] rounded-2xl bg-white p-4 shadow-lg">
                <img
                    src="<?= $game->image ?>.jpg"
                    alt="<?= $game->title ?>"
                    class="w-full"
                />

                <h2 class="text-base font-semibold my-3" lang="en"><?= $game->title ?></h2>

                <p class="flex items-center justify-between flex-wrap text-sm">
                    <span class="whitespace-nowrap">Ár: <?= number_format($game->price, 0, ',', ' ') ?> Ft</span>

                    <span class="rounded-full px-4 py-1 text-xs font-semibold whitespace-nowrap <?= $game->platformClass ?>">
                        <?= $game->platform ?>
                    </span>
                </p>
            </div>
        <?php endforeach; ?>
    </section>
</main>
