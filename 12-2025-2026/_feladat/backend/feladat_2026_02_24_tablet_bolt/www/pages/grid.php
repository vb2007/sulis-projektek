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
                <div
                    class="group rounded-xl border border-gray-200 bg-white p-4 shadow-sm transition hover:-translate-y-1 hover:shadow-lg"
                >
                    <img
                        src="https://placehold.net/default.png"
                        alt="ALTERNATÍV SZÖVEG"
                        class="mb-4 h-48 w-full rounded-lg object-contain"
                    />

                    <h2 class="mb-3 text-l font-semibold text-teal-600">
                        TERMÉK NEVE
                    </h2>

                    <ul class="space-y-1 text-sm text-gray-700">
                        <li>
                            <span class="font-semibold text-teal-600"
                                >Gyártó:</span
                            >
                            GYÁRTÓ
                        </li>
                        <li>
                            <span class="font-semibold text-teal-600"
                                >Kijelző:</span
                            >
                            KIJELZŐ_MÉRETE
                        </li>
                        <li>
                            <span class="font-semibold text-teal-600"
                                >Tárhely:</span
                            >
                            TÁEHELY_MÉRETE
                        </li>
                        <li>
                            <span class="font-semibold text-teal-600">OS:</span>
                            OS
                        </li>
                        <li class="pt-2 text-lg font-bold text-teal-700">
                            ÁR_FORMÁZOTT
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </body>
</html>
