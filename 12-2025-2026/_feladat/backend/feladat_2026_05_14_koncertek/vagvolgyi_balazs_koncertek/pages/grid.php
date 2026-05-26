<a href="index.php?action=create" class="bg-violet-600 text-white text-center p-1 rounded-md inline-block cursor-pointer font-bold">Koncert rögzítése</a>

<div class="grid md:grid-cols-2 lg:grid-cols-4 gap-4 my-4">
    <?php foreach ($concerts as $concert): ?>
        <div class="bg-violet-100 p-2 rounded-lg">
            <h2 class="text-xl font-bold mb-2"><?= $concert->name ?></h2>
            <ul class="mb-2">
                <li><?= ucfirst($concert->type) ?></li>
                <li><?= $concert->location ?></li>
                <li><?= $concert->date->format('Y-m-d H:i:s') ?></li>
                <li><span class="bg-violet-600 text-white p-1 rounded"><?= $concert->price ?> Ft</span></li>
            </ul>
            <a class="bg-violet-600 text-white text-center p-1 block rounded-md cursor-pointer font-bold">Tovább</a>
        </div>
    <?php endforeach; ?>
</div>