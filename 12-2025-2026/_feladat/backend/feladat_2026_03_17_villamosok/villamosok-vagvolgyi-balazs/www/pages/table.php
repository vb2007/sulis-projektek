<?php
use Budapest\Transport\TramLine; ?>

<?php include __DIR__ . "/../components/form.php"; ?>

<h1 class="text-4xl font-bold mb-4">Viszonylatok - <?= count(
    $lines,
) ?> találat</h1>

<div class="overflow-auto">
    <table class="w-full">
        <thead>
            <tr class="hover:bg-gray-100 border-b border-b-zinc-400">
                <?php
                $headers = ["Viszonylat", "Útvonal", "Hossz", "Első üzemnap"];
                foreach ($headers as $header): ?>
                    <th class="px-2 py-1 align-middle font-semibold whitespace-nowrap"><?= $header ?></th>
                <?php endforeach;
                ?>
            </tr>
        </thead>
        <tbody>
            <?php foreach ($lines as $line): ?>
                <tr class="hover:bg-gray-100 border-b border-b-zinc-400">
                    <td class="px-2 py-1 text-center">
                        <?= $line->number ?>
                    </td>
                    <td class="px-2 py-1 text-center"><?= $line->route ?></td>
                    <td class="px-2 py-1 text-center"><?= $line->length ?> km</td>
                    <td class="px-2 py-1 text-center"><?= $line->since ?></td>
                </tr>
            <?php endforeach; ?>
        </tbody>
    </table>
</div>
