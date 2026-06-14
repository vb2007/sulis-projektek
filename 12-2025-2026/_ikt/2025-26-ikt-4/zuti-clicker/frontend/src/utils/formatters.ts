const SUFFIXES = ["", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc"];

export function formatNumber(n: number, decimals = 2): string {
  if (!isFinite(n)) return "0";
  if (n < 1000) return Math.floor(n).toString();
  const exp = Math.min(Math.floor(Math.log10(n) / 3), SUFFIXES.length - 1);
  const suffix = SUFFIXES[exp] ?? "";
  const scaled = n / Math.pow(1000, exp);
  return scaled.toFixed(decimals) + suffix;
}

// TPS, per-unit production -> shows decimals when value < 100
export function formatRate(n: number): string {
  if (!isFinite(n) || n === 0) return "0.00";
  if (n < 100) return n.toFixed(2);
  if (n < 1000) return Math.floor(n).toString();
  const exp = Math.min(Math.floor(Math.log10(n) / 3), SUFFIXES.length - 1);
  const suffix = SUFFIXES[exp] ?? "";
  const scaled = n / Math.pow(1000, exp);
  return scaled.toFixed(2) + suffix;
}

export function formatTime(seconds: number): string {
  const s = Math.floor(seconds);
  if (s < 60) return `${s}s`;
  if (s < 3600) return `${Math.floor(s / 60)}m ${s % 60}s`;
  const h = Math.floor(s / 3600);
  const m = Math.floor((s % 3600) / 60);
  return `${h}h ${m}m`;
}
