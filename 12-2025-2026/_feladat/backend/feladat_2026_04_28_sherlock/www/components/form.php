<form method="POST" action="index.php?action=create" class="grid gap-4">
    <div class="gird grid-cols-1 gap-4">
        <label for="title">Cím</label>
        <input type="text" id="title" name="title" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
    </div>
    <div class="gird grid-cols-1 gap-4">
        <label for="length">Hossz</label>
        <input type="number" id="length" name="length" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
    </div>
    <div class="gird grid-cols-1 gap-4">
        <label for="director">Rendező</label>
        <input type="text" id="director" name="director" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
    </div>
    <div class="gird grid-cols-1 gap-4">
        <label for="writer">Író</label>
        <input type="text" id="writer" name="writer" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
    </div>
    <div class="gird grid-cols-1 gap-4">
        <label for="published">Megjelenés</label>
        <input type="date" id="published" name="published" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
    </div>
    <div class="gird grid-cols-1 gap-4">
        <label for="viewers">Nézők száma (millió)</label>
        <input type="number" id="viewers" name="viewers" class="px-2 py-2 border border-slate-300 focus:border-slate-500 focus:ring focus:ring-slate-500">
    </div>

    <div>
        <input type="submit" value="Mentés" class="text-white bg-gradient-to-r from-green-400">
    </div>
</form>
