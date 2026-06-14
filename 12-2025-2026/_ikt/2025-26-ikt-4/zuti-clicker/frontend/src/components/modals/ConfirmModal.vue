<script setup lang="ts">
defineProps<{
  title: string;
  body: string;
  confirmLabel: string;
  cancelLabel: string;
}>();

const emit = defineEmits<{
  confirm: [];
  cancel: [];
}>();
</script>

<template>
  <Teleport to="body">
    <div class="modal-backdrop" @click.self="emit('cancel')">
      <div class="modal" role="alertdialog" aria-modal="true">
        <h2 class="modal-title">{{ title }}</h2>
        <p class="modal-body">{{ body }}</p>
        <div class="modal-actions">
          <button class="btn-cancel" @click="emit('cancel')">{{ cancelLabel }}</button>
          <button class="btn-confirm" @click="emit('confirm')">{{ confirmLabel }}</button>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<style scoped>
.modal-backdrop {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.55);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1100;
  animation: fadeIn 180ms ease;
}

.modal {
  background: var(--bg-surface);
  border: 1px solid var(--border);
  border-radius: var(--radius-md);
  padding: 28px 32px 24px;
  width: 100%;
  max-width: 360px;
  animation: fadeScaleIn 200ms ease;
  box-shadow: 0 20px 60px rgba(0, 0, 0, 0.4);
}

.modal-title {
  font-size: 16px;
  font-weight: 800;
  color: var(--text-primary);
  margin-bottom: 10px;
}

.modal-body {
  font-size: 13px;
  color: var(--text-secondary);
  line-height: 1.6;
  margin-bottom: 24px;
}

.modal-actions {
  display: flex;
  gap: 8px;
  justify-content: flex-end;
}

.btn-cancel {
  padding: 8px 16px;
  background: var(--bg-elevated);
  border: 1px solid var(--border);
  color: var(--text-secondary);
  border-radius: var(--radius-sm);
  font-size: 13px;
  font-weight: 600;
  transition: all var(--transition-fast);
}
.btn-cancel:hover { border-color: var(--accent); color: var(--text-primary); }

.btn-confirm {
  padding: 8px 16px;
  background: #ef4444;
  color: #fff;
  border-radius: var(--radius-sm);
  font-size: 13px;
  font-weight: 700;
  transition: background var(--transition-fast);
}
.btn-confirm:hover { background: #dc2626; }
</style>
