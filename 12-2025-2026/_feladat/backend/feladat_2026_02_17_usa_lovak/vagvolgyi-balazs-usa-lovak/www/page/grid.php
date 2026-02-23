<div class="mx-auto max-w-7xl px-4 flex-grow">
    <h1 class="my-4 text-center text-4xl font-bold text-blue-700">
        <?= $title ?>
    </h1>

    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8 text-blue-700">
        <?php foreach ($horses as $horse): ?>
        <div class="horse h-full bg-white rounded-xl shadow-md p-4 flex flex-col border border-blue-200 transition hover:border-blue-700 hover:shadow-xl">
            <h2 class="text-xl font-semibold text-center"><?= $horse->breed ?></h2>

            <p class="text-center text-gray-500"><?= $horse->state ?> (<?= $horse->year ?>)</p>

            <img
                src="<?= $horse->path ?>"
                alt="<?= $horse->image ?>"
                class="my-2"
            />

            <p class="text-gray-700"><?= $horse->description ?></p>
        </div>
        <?php endforeach; ?>
    </div>
</div>
