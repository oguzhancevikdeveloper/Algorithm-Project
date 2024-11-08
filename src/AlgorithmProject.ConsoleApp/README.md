1 => Event ve TravelTimeEvent modelleri oluşturuldu.

2 => Tüm etkinlikler (events) ve seyahat süresi matrisleri (travelTimeMatrices) liste olarak tanımlandı.

3 =>activityCount: Kullanıcının toplamda kaç etkinliğe katılacağını tutan bir değişken.
   _totalPriority: Etkinliklerin toplam öncelik değerlerini tutan bir değişken.
    nowTime: Şu anki zaman, TimeOnly türünde 10:00 olarak alındı.

4 => Müsait Etkinlikler için: İçeriği sonradan doldurulacak bir liste oluşturuldu.

5 => nowTime ile uyumlu olan etkinlikler: Bu etkinlikler döngü şeklinde kontrol edilip, uygun olanlar "available" listeye eklendi.

6 => Öncelik sırasına göre sıralama: Müsait etkinlikler, öncelik değerlerine göre sıralandı. En yüksek önceliğe sahip olan etkinlik seçilip işleme devam edildi.

İş Kuralı: Eğer müsait zaman diliminde birden fazla etkinlik varsa, en yüksek önceliğe sahip etkinlik seçilmelidir.

7 => Öncelik eşleşmesi: Müsait olan etkinliklerden, önceliği seçilen etkinlik ile eşleşenler seçildi ve ilgili değişkenlere (0 veya null olanlar) atandı.

8 => Zaman güncellemesi: nowTime, katılınan etkinliğin bitiş saati olarak güncellendi. Önceden oluşan müsait etkinlikler listesi temizlendi ve tekrar bir etkinliğe katılabilmek için döngüye baştan girilebilmesi adına döngüdeki değişken -1'e set edildi.

9 => Yeni müsait etkinlikler: Yeni zaman diliminde gidilebilecek etkinlikler, temizlenen availableEvents listesine eklendi. Ayrıca, lokasyona gidilirken harcanacak zaman kontrol edilip listeye eklendi (TimeControl fonksiyonu ile).

10 => En verimli etkinlikler: En verimli şekilde gidilebilecek etkinlikler console’a yazdırıldı.

