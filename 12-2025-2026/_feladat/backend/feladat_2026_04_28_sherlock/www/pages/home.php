<!-- Nem volt benne a template-ben?? Minta alapján random összedobtam. -->
<div class="mx-auto min-w-7xl px-4">
    <h1 class="my-4 text-center text-4xl font-bold text-slate-600"><?= $title ?></h1>

    <div class="overflow-x-auto border border-slate-200 shadow-sm">
        <table class="min-w-full">
            <thead class="bg-slate-600 text-white">
                <tr>
                    <td class="px-4 py-2 font-bold">ID</td>
                    <td class="px-4 py-2 font-bold">Cím</td>
                    <td class="px-4 py-2 font-bold">Hossz</td>
                    <td class="px-4 py-2 font-bold">Rendező</td>
                    <td class="px-4 py-2 font-bold">Író</td>
                    <td class="px-4 py-2 font-bold">Megjelenés</td>
                    <td class="px-4 py-2 font-bold">Nézettség</td>
                </tr>
            </thead>
            <tbody>
                <?php foreach ($episodes as $episode): ?>
                    <tr class="odd:bg-slate-200">
                        <td class="px-4 py-2"><?= $episode->id ?></td>
                        <td class="px-4 py-2"><?= $episode->title ?></td>
                        <td class="px-4 py-2"><?= $episode->length ?></td>
                        <td class="px-4 py-2"><?= $episode->director ?></td>
                        <td class="px-4 py-2"><?= $episode->writer ?></td>
                        <td class="px-4 py-2"><?= $episode->published ?></td>
                        <td class="px-4 py-2">
                            <?= $episode->viewers > 0 ? $episode->viewers : "Ismeretlen" ?>
                        </td>
                    </tr>
                <?php endforeach; ?>
            </tbody>
        </table>
    </div>
</div>
