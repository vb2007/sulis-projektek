<div class="mx-auto max-w-7xl px-4 flex-grow">
    <h1 class="my-4 text-center text-4xl font-bold text-blue-700">
        <?= $title ?>
    </h1>

    <ul>
        <?php foreach ($horses as $horse): ?>
        <li class="my-2 pl-2 text-blue-700 border-l-2 border-blue-300">
            <?= $horse->breed ?> (<?= $horse->state ?> - <?= $horse->year ?>)
        </li>
        <?php endforeach; ?>
    </ul>
</div>
