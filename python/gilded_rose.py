# -*- coding: utf-8 -*-
SULFURAS = "Sulfuras, Hand of Ragnaros"
BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert"
AGED_BRIE = "Aged Brie"

class GildedRose(object):

    def item_factory(self, item):
        allowedItems = {
            "Backstage passes to a TAFKAL80ETC concert": BackstagePassItem,
            "Aged Brie": AgedBrieItem,
            "Sulfuras, Hand of Ragnaros": SulfurasItem,
        }

        for type_name, class_ in allowedItems.items():
            if type_name in item.name:
                return class_(item.name, item.sell_in, item.quality)

        return RegularItem(item.name, item.sell_in, item.quality)

    def __init__(self, items):
        self.items = items

    def update_quality(self):
        for item in self.items:
            casted_item = self.item_factory(item)
            item.sell_in = casted_item.get_updated_sellin()
            item.quality = casted_item.get_updated_quality()


class Item:
    def __init__(self, name, sell_in, quality):
        self.name = name
        self.sell_in = sell_in
        self.quality = quality

    def __repr__(self):
        return "%s, %s, %s" % (self.name, self.sell_in, self.quality)

class AgedBrieItem(Item):
    def get_updated_quality(self):
        if self.sell_in < 0 & self.quality < 49:
            self.quality += 2
        else:
            self.quality += 1

        return min([50, self.quality])
    
    def get_updated_sellin(self):
        return self.sell_in - 1

class BackstagePassItem(Item):
    def get_updated_quality(self):
        quality = self.quality + 1
        if self.sell_in < 0:
            quality = 0
        elif self.sell_in < 5:
            quality += 2
        elif self.sell_in < 10:
            quality += 1

        return min([50, quality])
    
    def get_updated_sellin(self):
        self.sell_in -= 1
        return self.sell_in

class SulfurasItem(Item):
    def get_updated_quality(self):
        return self.quality
    
    def get_updated_sellin(self):
        return self.sell_in

class RegularItem(Item):

    def get_updated_quality(self):
        if self.sell_in < 0:
            self.quality -= 2
        else:
            self.quality -= 1
        return max([0, self.quality])
    
    def get_updated_sellin(self):
        self.sell_in -= 1
        return self.sell_in
