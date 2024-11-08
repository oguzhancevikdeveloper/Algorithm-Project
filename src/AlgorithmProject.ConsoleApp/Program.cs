using AlgorithmProject.ConsoleApp.Models;

//Event ve TravelTimeEvent modelleri oluşturuldu.

//Tüm etkinlikler (events) ve seyahat süresi matrisleri (travelTimeMatrices) liste olarak tanımlandı.

//activityCount: Kullanıcının toplamda kaç etkinliğe katılacağını tutan bir değişken.
//_totalPriority: Etkinliklerin toplam öncelik değerlerini tutan bir değişken.
//nowTime: Şu anki zaman, TimeOnly türünde 10:00 olarak alındı.

//Müsait Etkinlikler için: İçeriği sonradan doldurulacak bir liste oluşturuldu.

//nowTime ile uyumlu olan etkinlikler: Bu etkinlikler döngü şeklinde kontrol edilip, uygun olanlar "available" listeye eklendi.

//Öncelik sırasına göre sıralama: Müsait etkinlikler, öncelik değerlerine göre sıralandı. En yüksek önceliğe sahip olan etkinlik seçilip işleme devam edildi.

//İş Kuralı: Eğer müsait zaman diliminde birden fazla etkinlik varsa, en yüksek önceliğe sahip etkinlik seçilmelidir.

//Öncelik eşleşmesi: Müsait olan etkinliklerden, önceliği seçilen etkinlik ile eşleşenler seçildi ve ilgili değişkenlere (0 veya null olanlar) atandı.

//Zaman güncellemesi: nowTime, katılınan etkinliğin bitiş saati olarak güncellendi. Önceden oluşan müsait etkinlikler listesi temizlendi ve tekrar bir etkinliğe katılabilmek için döngüye baştan girilebilmesi adına döngüdeki değişken -1'e set edildi.

//Yeni müsait etkinlikler: Yeni zaman diliminde gidilebilecek etkinlikler, temizlenen availableEvents listesine eklendi. Ayrıca, lokasyona gidilirken harcanacak zaman kontrol edilip listeye eklendi (TimeControl fonksiyonu ile).

//En verimli etkinlikler: En verimli şekilde gidilebilecek etkinlikler console’a yazdırıldı.



List<Event> events = new List<Event>()
{
    new Event(id:1,startTime:"10:00",endTime:"12:00",location:"A",priority:50),
    new Event(id:2,startTime:"10:00",endTime:"11:00",location:"B",priority:30),
    new Event(id:3,startTime:"11:30",endTime:"12:30",location:"A",priority:40),
    new Event(id:4,startTime:"14:30",endTime:"16:00",location:"C",priority:70),
    new Event(id:5,startTime:"14:25",endTime:"15:30",location:"B",priority:60),
    new Event(id:6,startTime:"13:00",endTime:"14:00",location:"D",priority:80)
};

List<TravelTimeEvent> travelTimeMatrices = new List<TravelTimeEvent>
{
    new TravelTimeEvent(from:"A",to :"B", durationTime:15),
    new TravelTimeEvent(from:"A",to :"C", durationTime:20),
    new TravelTimeEvent(from:"A",to :"D", durationTime:10),
    new TravelTimeEvent(from:"B",to :"C", durationTime:5),
    new TravelTimeEvent(from:"B",to :"D", durationTime:25),
    new TravelTimeEvent(from:"C",to :"D", durationTime:25),

};

int activityCount = 0;
int _totalPriority = 0;
List<int> activitiesId = new List<int>();
TimeOnly nowTime = new TimeOnly(10, 0);
string location = null;
List<Event> availableEvents = new List<Event>();

foreach (var item in events)
{
    if (nowTime == TimeOnly.Parse(item.StartTime)) availableEvents.Add(item);

}

for (int i = 0; i < availableEvents.Count; i++)
{
    var selectPriority = availableEvents.OrderByDescending(x => x.Priority).First();

    if (availableEvents[i].Priority == selectPriority.Priority)
    {
        _totalPriority += availableEvents[i].Priority;
        activityCount++;
        location = availableEvents[i].Location;
        activitiesId.Add(availableEvents[i].Id);
        nowTime = TimeOnly.Parse(availableEvents[i].StartTime);
        TimeSpan difference = DateTime.Parse(availableEvents[i].EndTime) - DateTime.Parse(availableEvents[i].StartTime);
        TimeOnly newTime = nowTime.Add(difference);
        nowTime = newTime;
        availableEvents.Clear();
        i = -1;
        foreach (var item in events)
        {
            if (nowTime <= TimeOnly.Parse(item.StartTime))
            {
                availableEvents.Add(item);
                availableEvents = availableEvents.OrderByDescending(x => x.Priority).ToList();
                if (!TimeControl(availableEvents, nowTime, selectPriority.Location)) availableEvents.Remove(selectPriority);
            }
        }
    }
}


Console.WriteLine("Katılınabilecek Maksimum Etkinlik Sayısı: " + activityCount);
Console.WriteLine("Katılınabilecek Etkinliklerin ID'leri: " + string.Join(", ", activitiesId));
Console.WriteLine("Toplam Değer: " + _totalPriority);

bool TimeControl(List<Event> events, TimeOnly nowTime, string location)
{

    travelTimeMatrices = travelTimeMatrices.Where(x => x.From == location).ToList();

    foreach (var item in travelTimeMatrices)
    {
        nowTime = nowTime.AddMinutes(item.DurationTime);
        foreach (var _item in events)
        {
            if (nowTime < TimeOnly.Parse(_item.StartTime)) return true;

            else return false;
        }
    }

    return true;
}
