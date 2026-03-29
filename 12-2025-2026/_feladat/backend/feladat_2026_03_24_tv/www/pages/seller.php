<main class="flex-1">
    <h1 class="my-4 text-center text-4xl font-bold text-cyan-600">
        <?= $title ?>
    </h1>

    <div class="mx-auto max-w-7xl px-4 py-10">
        <?php include __DIR__ . "/../components/form.php"; ?>

        <div class="overflow-x-auto rounded-xl border border-cyan-200 shadow-sm">
            <table class="min-w-full overflow-hidden rounded-xl">
                <thead class="bg-cyan-600 text-white">
                    <tr>
                        <?php
                        $columns = [
                            "Gyártó",
                            "Megnevezés",
                            "Átmérő",
                            "Felbontás",
                            "Technológia",
                            "Ár",
                        ];
                        foreach ($columns as $column): ?>
                            <th class="px-4 py-3 text-sm font-semibold text-center first:text-left last:text-right">
                                <?= $column ?>
                            </th>
                        <?php endforeach;
                        ?>
                    </tr>
                </thead>

                <tbody class="divide-y divide-cyan-100">
                    <?php foreach ($televisions as $tv): ?>
                        <tr class="odd:bg-white even:bg-cyan-50 hover:bg-cyan-100 transition">
                            <td class="px-4 py-2 text-left"><?= $tv->manufacturer_name ?></td>
                            <td class="px-4 py-2 text-left"><?= $tv->name ?></td>
                            <td class="px-4 py-2 text-center"><?= $tv->size ?>&nbsp;hüvelyk</td>
                            <td class="px-4 py-2 text-center"><?= $tv->resolution ?></td>
                            <td class="px-4 py-2 text-center"><?= $tv->technology ?></td>
                            <td class="px-4 py-2 text-right font-bold text-cyan-700">
                                <?= number_format(
                                    $tv->price,
                                    0,
                                    ",",
                                    "&nbsp;",
                                ) ?>&nbsp;Ft
                            </td>
                        </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
    </div>
</main>
