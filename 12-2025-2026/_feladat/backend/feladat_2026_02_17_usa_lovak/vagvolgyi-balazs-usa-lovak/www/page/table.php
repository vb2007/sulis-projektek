<div class="mx-auto max-w-7xl px-4 flex-grow">
    <h1 class="my-4 text-center text-4xl font-bold text-blue-700">
        <?= $title ?>
    </h1>

    <div class="w-full">
        <table class="min-w-full border border-blue-200 overflow-hidden">
            <thead class="bg-blue-700 text-white">
                <tr>
                    <th class="px-4 py-3 text-left text-sm font-bold">Állam</th>
                    <th class="px-4 py-3 text-left text-sm font-bold">Fajta</th>
                    <th class="px-4 py-3 text-left text-sm font-bold">Leírás</th>
                    <th class="px-4 py-3 text-left text-sm font-bold">Év</th>
                </tr>
            </thead>

            <tbody class="divide-y divide-blue-100 bg-white">
                <?php foreach ($horses as $horse): ?>
                <tr class="odd:bg-blue-50 transition">
                    <td class="px-4 py-3 text-sm text-gray-700"><?= $horse->state ?></td>
                    <td class="px-4 py-3 text-sm text-gray-700 font-bold"><?= $horse->breed ?></td>
                    <td class="px-4 py-3 text-sm text-gray-700"><?= $horse->description ?></td>
                    <td class="px-4 py-3 text-sm text-gray-700"><?= $horse->year ?></td>
                </tr>
                <?php endforeach; ?>
            </tbody>
        </table>
    </div>
</div>
