<main class="flex-1">
    <h1 class="my-4 text-center text-4xl font-bold text-cyan-600">
        <?= $title ?>
    </h1>

    <div class="mx-auto max-w-7xl px-4 py-10">
        <?php include __DIR__ . "/../components/form.php"; ?>

        <div class="grid grid-cols-1 gap-8 md:grid-cols-2 lg:grid-cols-3">
            <?php foreach ($televisions as $tv): ?>
                <div class="group rounded-xl border border-gray-200 bg-white p-4">
                    <img
                        src="<?= $tv->getImagePath() ?>"
                        alt="<?= $tv->name ?>"
                        class="mb-4 h-48 w-full rounded-lg object-contain"
                    />

                    <h2 class="mb-3 text-l font-semibold text-cyan-600">
                        <?= $tv->name ?>
                    </h2>

                    <ul class="space-y-1 text-sm text-gray-700">
                        <li>
                            <span class="font-semibold text-cyan-600">Gyártó:</span>
                            <?= $tv->manufacturer_name ?>
                        </li>
                        <li>
                            <span class="font-semibold text-cyan-600 inline-flex gap-4">
                                Kijelző:
                            </span>
                            <span class="inline-flex items-center rounded-full bg-cyan-100 px-2.5 py-0.5 text-sm font-medium text-cyan-800">
                                <?= $tv->size ?>&nbsp;hüvelyk&nbsp;<?= $tv->technology ?>
                            </span>
                            <span class="inline-flex items-center rounded-full bg-cyan-100 px-2.5 py-0.5 text-sm font-medium text-cyan-800">
                                <?= $tv->resolution ?>
                            </span>
                            <?php if ($tv->hdr): ?>
                                <span class="inline-flex items-center rounded-full bg-cyan-100 px-2.5 py-0.5 text-sm font-medium text-cyan-800">
                                    HDR
                                </span>
                            <?php endif; ?>
                        </li>
                    </ul>

                    <div class="pt-2 text-lg font-bold text-cyan-700 text-right">
                        <?= number_format(
                            $tv->price,
                            0,
                            ",",
                            "&nbsp;",
                        ) ?>&nbsp;Ft
                    </div>
                </div>
            <?php endforeach; ?>
        </div>
    </div>
</main>
