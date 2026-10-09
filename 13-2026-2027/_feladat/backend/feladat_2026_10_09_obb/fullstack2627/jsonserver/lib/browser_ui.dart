import 'package:shelf/shelf.dart';

import 'database.dart';

/// Returns a shelf Handler that serves a read-only resource browser at GET /.
///
/// Lists all collections from db.json; clicking one fetches the JSON endpoint
/// and renders the response inline.
Handler buildBrowserUiHandler(JsonDatabase db) {
  return (Request request) {
    if (request.method != 'GET') {
      return Response(405, body: 'Method Not Allowed');
    }

    final collections = db.collections;
    final listItems = collections.map((name) => '''
        <li>
          <button onclick="load('/$name')" aria-label="Browse $name">
            <span class="method">GET</span>
            <span class="path">/$name</span>
            <span class="count">${db.rawCollection(name).length} items</span>
          </button>
        </li>''').join('\n');

    final html = '''<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>JSON Server</title>
<style>
  *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }
  body { font-family: system-ui, sans-serif; background: #0f1117; color: #e2e8f0; min-height: 100vh; }
  header { padding: 1.5rem 2rem; border-bottom: 1px solid #1e2535; display: flex; align-items: center; gap: 1rem; }
  header h1 { font-size: 1.1rem; font-weight: 600; letter-spacing: .02em; }
  header span { font-size: .75rem; color: #64748b; background: #1e2535; padding: .2rem .6rem; border-radius: 999px; }
  main { display: grid; grid-template-columns: 280px 1fr; height: calc(100vh - 57px); }
  aside { border-right: 1px solid #1e2535; overflow-y: auto; padding: 1rem 0; }
  aside ul { list-style: none; }
  aside li button {
    width: 100%; display: flex; align-items: center; gap: .75rem;
    padding: .65rem 1.25rem; border: none; background: none; cursor: pointer;
    color: #cbd5e1; font-size: .875rem; text-align: left; transition: background .15s;
  }
  aside li button:hover, aside li button.active { background: #1e2535; color: #f1f5f9; }
  .method { font-size: .7rem; font-weight: 700; color: #22d3ee; background: #0e3344; padding: .15rem .4rem; border-radius: 4px; flex-shrink: 0; }
  .path { flex: 1; font-family: monospace; }
  .count { font-size: .75rem; color: #475569; flex-shrink: 0; }
  section { display: flex; flex-direction: column; overflow: hidden; }
  #toolbar { padding: .75rem 1.25rem; border-bottom: 1px solid #1e2535; display: flex; align-items: center; gap: .75rem; background: #0f1117; }
  #url-display { font-family: monospace; font-size: .85rem; color: #94a3b8; flex: 1; }
  #status-badge { font-size: .75rem; font-weight: 600; padding: .2rem .6rem; border-radius: 4px; display: none; }
  #status-badge.ok { background: #052e16; color: #4ade80; display: inline-block; }
  #status-badge.err { background: #3b0000; color: #f87171; display: inline-block; }
  #output { flex: 1; overflow-y: auto; padding: 1.25rem; }
  #output pre { font-family: monospace; font-size: .8rem; line-height: 1.6; white-space: pre-wrap; word-break: break-word; color: #e2e8f0; }
  #placeholder { display: flex; flex-direction: column; align-items: center; justify-content: center; height: 100%; color: #334155; text-align: center; gap: .5rem; }
  #placeholder svg { opacity: .3; }
  #placeholder p { font-size: .875rem; }
</style>
</head>
<body>
<header>
  <h1>JSON Server</h1>
  <span>read-only browser</span>
</header>
<main>
  <aside>
    <ul id="collection-list">
      $listItems
    </ul>
  </aside>
  <section>
    <div id="toolbar">
      <span id="url-display">Select a collection</span>
      <span id="status-badge"></span>
    </div>
    <div id="output">
      <div id="placeholder">
        <svg width="48" height="48" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M4 6h16M4 12h16M4 18h7"/></svg>
        <p>Click a collection to browse its data</p>
      </div>
      <pre id="json-display" style="display:none"></pre>
    </div>
  </section>
</main>
<script>
  let activeBtn = null;

  async function load(path) {
    const urlEl = document.getElementById('url-display');
    const badge = document.getElementById('status-badge');
    const pre = document.getElementById('json-display');
    const placeholder = document.getElementById('placeholder');

    if (activeBtn) activeBtn.classList.remove('active');
    activeBtn = event.currentTarget;
    activeBtn.classList.add('active');

    urlEl.textContent = path;
    badge.className = '';
    badge.textContent = '';
    pre.style.display = 'none';
    placeholder.style.display = 'none';

    try {
      const res = await fetch(path);
      badge.textContent = res.status + ' ' + res.statusText;
      badge.className = res.ok ? 'ok' : 'err';
      const data = await res.json();
      pre.textContent = JSON.stringify(data, null, 2);
      pre.style.display = 'block';
    } catch (e) {
      badge.textContent = 'Network error';
      badge.className = 'err';
      pre.textContent = String(e);
      pre.style.display = 'block';
    }
  }
</script>
</body>
</html>''';

    return Response.ok(html, headers: {'content-type': 'text/html; charset=utf-8'});
  };
}
