import { createPinia, setActivePinia } from 'pinia'
import { beforeEach, describe, expect, it } from 'vitest'
import { useCounter } from '@stores/CounterStore'

describe('useCounter', () => {
  beforeEach(() => {
    setActivePinia(createPinia())
  })

  it('starts at zero', () => {
    const store = useCounter()
    expect(store.counter).toBe(0)
  })

  it('increments by 1 by default', () => {
    const store = useCounter()
    store.increment()
    expect(store.counter).toBe(1)
  })

  it('increments by the given step', () => {
    const store = useCounter()
    store.increment(5)
    expect(store.counter).toBe(5)
  })

  it('computes counter10X as ten times the counter', () => {
    const store = useCounter()
    store.increment(3)
    expect(store.counter10X).toBe(30)
  })
})
