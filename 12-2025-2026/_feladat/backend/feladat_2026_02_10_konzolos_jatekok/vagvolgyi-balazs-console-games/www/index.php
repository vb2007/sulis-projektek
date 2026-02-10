<?php
declare(strict_types=1);

$whoops = new \Whoops\Run;
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler);
$whoops->register();

$title = "Videójátékok";
$backgroundColor = "lightcoral";

ob_start();
?>

<!doctype html>
<html lang="hu">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title><?= $title ?></title>
        <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
        <style>
            body {
                background-color: <?= $backgroundColor ?>;
            }
        </style>
    </head>
    <body>
        <main class="mx-auto max-w-7xl px-4 py-6">
            <h1 class="mb-6 text-4xl font-bold text-center"><?= $title ?></h1>

            <section id="games" class="grid grid-cols-1 gap-6">
                <div
                    class="grid grid-rows-[auto_1fr_auto] rounded-2xl bg-white p-4 shadow-lg"
                >
                    <img
                        src="https://picsum.photos/id/223/260/260"
                        class="w-full"
                    />

                    <h2 class="text-base font-semibold">Cím</h2>

                    <p
                        class="flex items-center justify-between flex-wrap text-sm"
                    >
                        <span class="whitespace-nowrap"> Ár: 15 990 Ft </span>

                        <span
                            class="rounded-full px-4 py-1 text-xs font-semibold whitespace-nowrap"
                        >
                            PS5
                        </span>
                    </p>
                </div>
            </section>
        </main>
    </body>
</html>

<?php
ob_end_flush();
?>
