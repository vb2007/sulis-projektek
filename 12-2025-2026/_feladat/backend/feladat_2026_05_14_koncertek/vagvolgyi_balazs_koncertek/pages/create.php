<form action="index.php?action=store" method="post" class="w-11/12 max-w-100 mx-auto grid md:grid-cols-[auto_1fr] gap-2">
    <div class="grid grid-cols-subgrid col-span-2">
        <label for="name">Név</label>
        <input type="text" name="name" id="name" class="border rounded border-gray-500 focus:border-violet-600 px-1">
        <p class="col-span-full text-red-600 mt-2"><!-- Hiba --></p>
    </div>
    <div class="grid grid-cols-subgrid col-span-2">
        <label for="location">Helyszín</label>
        <input type="text" name="location" id="location" class="border rounded border-gray-500 focus:border-violet-600 px-1">
        <p class="col-span-full text-red-600 mt-2"><!-- Hiba --></p>
    </div>
    <div class="grid grid-cols-subgrid col-span-2">
        <label for="type">Típus</label>
        <select name="type" id="type" class="border rounded border-gray-500 focus:border-violet-600">
        </select>
        <p class="col-span-full text-red-600 mt-2"><!-- Hiba --></p>
    </div>
    <div class="grid grid-cols-subgrid col-span-2">
        <label for="date">Dátum</label>
        <input type="date" name="date" id="date" class="border rounded border-gray-500 focus:border-violet-600 px-1"> 
        <p class="col-span-full text-red-600 mt-2"><!-- Hiba --></p>
    </div>
    <div class="grid grid-cols-subgrid col-span-2">
        <label for="price">Ár</label>
        <input type="number" name="price" id="price" class="border rounded border-gray-500 focus:border-violet-600 px-1"> 
        <p class="col-span-full text-red-600 mt-2"><!-- Hiba --></p>
    </div>
    <input type="submit" value="Rögzítés" class="bg-violet-600 text-white text-center p-1 rounded-md cursor-pointer font-bold col-span-full">
</form>