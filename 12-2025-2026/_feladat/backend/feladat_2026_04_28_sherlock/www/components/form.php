<form method="POST" action="index.php?action=create" class="grid gap-4">
    <div class="grid grid-cols-1 gap-1">
        <label for="title">Cím</label>
        <input type="text" id="title" name="title" value="<?= $data["title"] ??
            "" ?>" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
        <?php if (isset($errors["title"])): ?>
            <p class="text-red-600"><?= $errors["title"] ?></p>
        <?php endif; ?>
    </div>

    <div class="grid grid-cols-1 gap-1">
        <label for="length">Hossz</label>
        <input type="number" id="length" name="length" value="<?= $data["length"] ??
            0 ?>" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
        <?php if (isset($errors["length"])): ?>
            <p class="text-red-600"><?= $errors["length"] ?></p>
        <?php endif; ?>
    </div>

    <div class="grid grid-cols-1 gap-1">
        <label for="director">Rendező</label>
        <input type="text" id="director" name="director" value="<?= $data["director"] ??
            "" ?>" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
        <?php if (isset($errors["director"])): ?>
            <p class="text-red-600"><?= $errors["director"] ?></p>
        <?php endif; ?>
    </div>

    <div class="grid grid-cols-1 gap-1">
        <label for="writer">Író</label>
        <input type="text" id="writer" name="writer" value="<?= $data["writer"] ??
            "" ?>" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
        <?php if (isset($errors["writer"])): ?>
            <p class="text-red-600"><?= $errors["writer"] ?></p>
        <?php endif; ?>
    </div>

    <div class="grid grid-cols-1 gap-1">
        <label for="published">Megjelenés</label>
        <input type="date" id="published" name="published" value="<?= $data["published"] ??
            date("Y-m-d") ?>" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
        <?php if (isset($errors["published"])): ?>
            <p class="text-red-600"><?= $errors["published"] ?></p>
        <?php endif; ?>
    </div>

    <div class="grid grid-cols-1 gap-1">
        <label for="viewers">Nézők száma (millió)</label>
        <input type="number" step="0.01" id="viewers" name="viewers" value="<?= $data["viewers"] ??
            0 ?>" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
        <?php if (isset($errors["viewers"])): ?>
            <p class="text-red-600"><?= $errors["viewers"] ?></p>
        <?php endif; ?>
    </div>

    <div>
        <input type="submit" value="Mentés" class="px-4 py-2 text-white bg-gradient-to-r from-green-400 via-green-500 to-green-600 hover:bg-gradient-to-br focus:ring-4 focus:outline-none focus:ring-green-300 font-medium rounded-lg text-sm cursor-pointer">
    </div>
</form>
