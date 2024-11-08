## Event ve TravelTimeEvent Modelleri

- **Event** ve **TravelTimeEvent** modelleri oluşturuldu.
- Tüm etkinlikler (`events`) ve seyahat süresi matrisleri (`travelTimeMatrices`) liste olarak tanımlandı.

### Temel Değişkenler:

- **activityCount**: Kullanıcının katılacağı toplam etkinlik sayısını tutar.
- **_totalPriority**: Etkinliklerin toplam öncelik değerlerini tutar.
- **nowTime**: Şu anki zamanı, `TimeOnly` türünde `10:00` olarak alır.

### Etkinlik Yönetimi:

1. **Müsait Etkinlikler**: İçeriği sonradan doldurulacak bir liste oluşturuldu.
   
2. **Etkinlik Eşleştirme**: Etkinlikler, `nowTime` ile uyumlu olup olmadıkları açısından döngüyle kontrol edilip uygun olanlar `available` listesine eklendi.
   
3. **Öncelik Sıralaması**: Müsait etkinlikler, öncelik değerlerine göre sıralandı. En yüksek önceliğe sahip etkinlik seçilip işleme devam edildi.
   
4. **İş Kuralı**: Eğer müsait zaman diliminde birden fazla etkinlik varsa, en yüksek önceliğe sahip etkinlik seçilmelidir.

5. **Öncelik Eşleşmesi**: Müsait etkinliklerden, önceliği seçilen etkinlik ile eşleşenler seçildi ve ilgili değişkenlere (0 veya null olanlar) atandı.

6. **Zaman Güncellemesi**: Seçilen etkinliğin bitiş saati ile `nowTime` güncellendi. Önceden oluşan müsait etkinlikler listesi temizlendi ve döngüdeki değişkenler yeniden başlatıldı (değeri `-1` olarak ayarlandı).

### Yeni Müsait Etkinlikler:

- Yeni zaman diliminde gidilebilecek etkinlikler, temizlenen `availableEvents` listesine eklendi.
- Lokasyona gidilirken harcanacak zaman, `TimeControl` fonksiyonu ile kontrol edilip listeye eklendi.

### En Verimli Etkinlikler:

- En verimli şekilde gidilebilecek etkinlikler konsola yazdırıldı.
