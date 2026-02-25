<!doctype html>
<html lang="hu">
    <head>
        <meta charset="UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title><?= $title ?></title>
        <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
        <link rel="stylesheet" href="./css/tablet.css" />
    </head>
    <body class="min-h-screen flex flex-col">
        <div class="mx-auto max-w-7xl px-4">
            <h1 class="my-4 text-center text-4xl font-bold text-teal-600">
                <?= $title ?>
            </h1>
            <div class="grid grid-cols-1 gap-8 md:grid-cols-2 lg:grid-cols-3">
                <?php foreach ($tablets as $tablet): ?>
                    <div
                        class="group rounded-xl border border-gray-200 bg-white p-4 shadow-sm transition hover:-translate-y-1 hover:shadow-lg"
                    >
                        <img
                            src="<?= $tablet->getImagePath() ?>"
                            alt="<?= $tablet->fullname ?>"
                            class="mb-4 h-48 w-full rounded-lg object-contain"
                        />
                        <h2 class="mb-3 text-l font-semibold text-teal-600">
                            <?= $tablet->fullname ?>
                        </h2>
                        <ul class="space-y-1 text-sm text-gray-700">
                            <li>
                                <span class="font-semibold text-teal-600"
                                    >Gyártó:</span
                                >
                                <?= $tablet->manufacturer ?>
                            </li>
                            <li>
                                <span class="font-semibold text-teal-600"
                                    >Kijelző:</span
                                >
                                <?= $tablet->screen ?>"
                            </li>
                            <li>
                                <span class="font-semibold text-teal-600"
                                    >Tárhely:</span
                                >
                                <?= $tablet->storage ?> GB
                            </li>
                            <li>
                                <span class="font-semibold text-teal-600">OS:</span>
                                <?= $tablet->os ?>
                            </li>
                            <li class="pt-2 text-lg font-bold text-teal-700">
                                <?= number_format($tablet->price, 0, ',', ' ') ?> Ft
                            </li>
                        </ul>
                    </div>
                <?php endforeach; ?>
            </div>
        </div>
    </body>
</html>
