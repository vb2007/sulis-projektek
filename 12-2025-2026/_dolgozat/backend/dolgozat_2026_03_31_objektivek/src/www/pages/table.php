<?php $headers = [
    "Bajonett",
    "Név",
    "Min. gyújtótávolság",
    "Max. gyújtótávolság",
    "Min. rekesz",
    "Max. rekesz",
    "Típus",
]; ?>

<h1 class="text-3xl text-center mb-4"><?= $title ?> (<?= count(
     $lenses,
 ) ?> db) - táblázat</h1>

<?php include __DIR__ . "/../components/form.php"; ?>

<table class="mx-auto">
    <thead>
        <tr>
            <?php foreach ($headers as $header): ?>
                <th class="py-1 px-2 bg-zinc-600 text-white"><?= $header ?></th>
            <?php endforeach; ?>
        </tr>
    </thead>
    <tbody>
        <?php foreach ($lenses as $lens): ?>
            <tr class="even:bg-zinc-50 odd:bg-white">
                <td class="p-1 text-center"><?= $lens->mount ?></td>
                <td class="p-1 text-center"><?= $lens->name ?></td>
                <td class="p-1 text-center"><?= $lens->minFocalLength ?>mm</td>
                <td class="p-1 text-center"><?= $lens->maxFocalLength ?>mm</td>
                <td class="p-1 text-center">f/<?= $lens->minAperture ?></td>
                <td class="p-1 text-center">f/<?= $lens->maxAperture ?></td>
                <td class="p-1 text-center"><?= \Media\Camera\Lens::getAvailableTypes()[
                    $lens->type
                ] ?></td>
            </tr>
        <?php endforeach; ?>
    </tbody>
</table>
