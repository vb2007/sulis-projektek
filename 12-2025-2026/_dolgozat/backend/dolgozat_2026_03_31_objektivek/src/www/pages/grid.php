<h1 class="text-3xl text-center mb-4"><?= $title ?> (<?= count(
     $lenses,
 ) ?> db) - rács</h1>

<?php include __DIR__ . "/../components/form.php"; ?>

<div class="grid md:grid-cols-2 lg:grid-cols-3 gap-2 max-w-300 mx-auto">
    <?php foreach ($lenses as $lens): ?>
            <div class="bg-white px-4 py-2 shadow-sm">
                <img class="w-1/2 mx-auto mb-2" src="<?= $lens->image ?>" alt="<?= $lens->name ?>">
                <h2 class="text-lg font-semibold">
    <?= $lens->mount ?> <?= $lens->minFocalLength == $lens->maxFocalLength
     ? $lens->minFocalLength
     : "{$lens->minFocalLength}-$lens->maxFocalLength" ?>mm f/<?= $lens->minAperture ==
$lens->maxAperture
    ? $lens->minAperture
    : "{$lens->minAperture}-$lens->maxAperture" ?> <?= $lens->name ?>
                </h2>
                <p><?= \Media\Camera\Lens::getAvailableTypes()[
                    $lens->type
                ] ?></p>
            </div>
    <?php endforeach; ?>
</div>
