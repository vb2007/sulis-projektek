<script setup>
import {
  NavigationMenu,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuItem,
  navigationMenuTriggerStyle
} from '@components/ui/navigation-menu'
import { Sheet, SheetContent, SheetTrigger } from '@components/ui/sheet'

const title = import.meta.env.VITE_APP_NAME

const links = [
  {
    label: 'Page',
    to: '#'
  }
]
</script>

<template>
  <header class="bg-white">
    <div class="flex justify-between p-3 border-b-2 flex-wrap">
      <RouterLink to="/" class="flex items-center space-x-3">
        <span class="self-center text-2xl font-semibold">{{ title }}</span>
      </RouterLink>
      <Sheet>
        <SheetTrigger asChild>
          <button variant="outline" size="icon" class="lg:hidden">
            <svg
              class="h-6 w-6"
              xmlns="http://www.w3.org/2000/svg"
              width="24"
              height="24"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              strokeWidth="2"
              strokeLinecap="round"
              strokeLinejoin="round"
            >
              <line x1="4" x2="20" y1="12" y2="12" />
              <line x1="4" x2="20" y1="6" y2="6" />
              <line x1="4" x2="20" y1="18" y2="18" />
            </svg>
            <span class="sr-only">Navigációs menü</span>
          </button>
        </SheetTrigger>
        <SheetContent side="left">
          <RouterLink to="/" class="mr-6 hidden lg:flex">
            <span class="sr-only">{{ title }}</span>
          </RouterLink>
          <div class="grid gap-2 py-6">
            <RouterLink
              v-for="link of links"
              :key="link.to"
              :to="link.to"
              class="flex w-full items-center py-2 text-lg font-semibold"
            >
              {{ link.label }}
            </RouterLink>
          </div>
        </SheetContent>
      </Sheet>
      <NavigationMenu class="hidden lg:block">
        <NavigationMenuList>
          <NavigationMenuItem v-for="link of links" :key="link.to">
            <RouterLink v-slot="{ isActive, href, navigate }" :to="link.to" custom>
              <NavigationMenuLink
                :active="isActive"
                :href
                :class="navigationMenuTriggerStyle()"
                @click="navigate"
              >
                {{ link.label }}
              </NavigationMenuLink>
            </RouterLink>
          </NavigationMenuItem>
        </NavigationMenuList>
      </NavigationMenu>
    </div>
  </header>
</template>
