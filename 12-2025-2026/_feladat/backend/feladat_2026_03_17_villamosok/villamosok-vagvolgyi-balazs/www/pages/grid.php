<?php require __DIR__ . "/../components/form.php"; ?>

<h1 class="text-4xl font-bold mb-4">Viszonylatok - <?= count(
    $lines,
) ?> találat</h1>

<div class="grid md:grid-cols-3 xl:grid-cols-6 gap-2">
    <?php foreach ($lines as $line): ?>
    <div class="border border-zinc-400 rounded hover:bg-gray-100 flex flex-col">
        <img src="<?= $line->getImagePath() ?>" class="h-65 md:h-50 xl:h-35 w-full object-cover rounded-[0.18rem]" alt="<?= $line->number ?> villamos">
        <div class="p-2 flex flex-col grow">
            <h2 class="text-xl font-semibold mb-1">
                <?= $line->number ?>
            </h2>
            <p>
                <?= $line->length ?> km
            </p>
            <p class="text-sm grow mb-2">
                <?= $line->route ?>
            </p>
            <span class="text-sm py-1 px-2 bg-black text-white self-start rounded">
                <?= $line->getInterconnected() ?>
            </span>
        </div>
    </div>
    <?php endforeach; ?>
</div>
