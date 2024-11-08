## Event ve TravelTimeEvent Modelleri

1. **Event** ve **TravelTimeEvent** modelleri oluşturuldu.
2. Tüm **events** ve **travelTimeMatrices** liste şeklinde tanımlandı.

### Temel Değişkenler:

3. **activityCount**: Kullanıcının katılacağı toplam etkinlik sayısını tutar.  
   **_totalPriority**: Etkinliklerin toplam öncelik değerlerinin toplamını tutar.  
   **activitiesId**: Başarıyla gidilen etkinliklerin ID bilgilerini tutan bir listedir.  
   **location**: İlgili etkinlikten sonra potansiyel gidilebilecek olan etkinliklerin mesafe olarak zamanını ölçmek için kullanılan değişkendir.  
   **nowTime**: Şu anki zaman, `TimeOnly` türünde (10:00 olarak alındı).

4. **Available Events**: İçeriği sonradan doldurulacak bir liste oluşturuldu.

### Etkinlik Yönetimi:

5. **Etkinlik Eşleştirme**: `nowTime` ile uyumlu olan etkinlikler döngü şeklinde kontrol edilip, uygun olanlar `available` listesine eklendi.
   
6. **Öncelik Sıralaması**: Potansiyel gidilebilecek etkinlikler, öncelik sırasına göre sıralandı. En yüksek önceliğe sahip etkinlik seçilip işleme devam edildi.

#### İş Kuralı:
- Müsait zamanda birden fazla etkinlik varsa, en yüksek önceliğe sahip olan etkinlik seçilmelidir.

7. **Öncelik Eşleşmesi**: Müsait olan etkinliklerden, önceliği seçilen etkinlik ile eşleşenler seçildi ve ilgili değişkenlere (0 veya null olanlar) atandı.

8. **Zaman Güncellemesi**: `nowTime`, katılınan etkinliğin bitiş saati olarak güncellendi. Önceden oluşan müsait etkinlikler listesi temizlendi. Döngüdeki değişkenler ise -1'e set edilerek tekrar bir etkinliğe katılabilmesi için döngü baştan başlatıldı.

9. **Yeni Müsait Etkinlikler**: Yeni zaman diliminde gidilebilecek etkinlikler, temizlenen `availableEvents` listesine eklendi. Lokasyona gidilirken harcanacak zaman da kontrol edilip listeye eklendi (TimeControl fonksiyonu ile).

10. **En Verimli Etkinlikler**: En verimli şekilde gidilebilecek etkinlikler konsola yazdırıldı.
