<h1 class="text-3xl font-bold text-center my-4"><?= $title ?></h1>

<form action="index.php?action=create" method="post" class="grid md:grid-cols-[auto_1fr] gap-2 w-11/12 max-w-400 mx-auto p-4 mb-4 rounded-lg bg-lime-50 drop-shadow-md">
    <div class="grid grid-cols-subgrid col-span-full items-center">
        <label for="name">Név</label>
        <input type="text" id="name" name="name" class="border border-lime-600 focus:border-lime-400 rounded-lg p-1 bg-emerald-50"
            value="<?= $data["name"] ?>">
        <?php if (isset($errors["name"])): ?>
            <p class="text-red-700 mb-2 col-span-full"><?= $errors["name"] ?></p>
        <?php endif; ?>
    </div>
    <div class="grid grid-cols-subgrid col-span-full items-center">
        <label for="address">Cím</label>
        <input type="text" id="address" name="address" class="border border-lime-600 focus:border-lime-400 rounded-lg p-1 bg-emerald-50"
            value="<?= $data["address"] ?>">
        <?php if (isset($errors["address"])): ?>
            <p class="text-red-700 mb-2 col-span-full"><?= $errors["address"] ?></p>
        <?php endif; ?>
    </div>
    <div class="grid grid-cols-subgrid col-span-full items-center">
        <label for="rooms">Szobák száma</label>
        <input type="number" id="rooms" name="rooms" step="0.5" class="border border-lime-600 focus:border-lime-400 rounded-lg p-1 bg-emerald-50"
            value="<?= $data["rooms"] ?>">
        <?php if (isset($errors["rooms"])): ?>
            <p class="text-red-700 mb-2 col-span-full"><?= $errors["rooms"] ?></p>
        <?php endif; ?>
    </div>
    <div class="grid grid-cols-subgrid col-span-full items-center">
        <label for="price">Ár/hó (forintban)</label>
        <input type="number" id="price" name="price" class="border border-lime-600 focus:border-lime-400 rounded-lg p-1 bg-emerald-50"
            value="<?= $data["price"] ?>">
        <?php if (isset($errors["price"])): ?>
            <p class="text-red-700 mb-2 col-span-full"><?= $errors["price"] ?></p>
        <?php endif; ?>
    </div>
    <input type="submit" value="Létrehozás" class="md:col-start-2 justify-self-end p-2 bg-lime-400 rounded-lg cursor-pointer">
</form>
