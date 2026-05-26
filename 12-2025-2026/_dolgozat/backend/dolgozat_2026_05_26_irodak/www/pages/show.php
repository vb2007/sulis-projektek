<h1 class="text-3xl font-bold text-center my-4"><?= $title ?></h1>

<div class="grid md:grid-cols-2 lg:grid-cols-[300px_300px_1fr_1fr] gap-4 w-11/12 max-w-400 mx-auto p-4 mb-4 rounded-lg bg-lime-50 drop-shadow-md">
    <div class="md:col-span-2 md:row-span-2 flex justify-center">
        <img src="<?= $offices[$id-1]->image ?>" alt="<?= $offices[$id-1]->name ?>" class="w-full max-w-[400px] rounded-lg">
    </div>
    <div class="md:col-span-2 bg-lime-100 rounded-lg overflow-hidden shadow">
        <h2 class="bg-lime-400 py-1 px-2 font-bold text-xl">Cím</h2>
        <p class="py-1 px-2 text-xl"><?= $offices[$id-1]->name ?></p>
    </div>
    <div class="bg-lime-100 rounded-lg overflow-hidden shadow">
        <h2 class="bg-lime-400 py-1 px-2 font-bold text-xl" >Szobák száma</h2>
        <p class="py-1 px-2 text-xl"><?= $offices[$id-1]->rooms ?></p>
    </div>
    <div class="bg-lime-100 rounded-lg overflow-hidden shadow">
        <h2 class="bg-lime-400 py-1 px-2 font-bold text-xl">Ár</h2>
        <p class="py-1 px-2 text-xl"><?= $offices[$id-1]->rooms ?></p>
    </div>
    <a href="index.php" class="text-blue-800 hover:underline">Vissza a főoldalra</a>
</div>