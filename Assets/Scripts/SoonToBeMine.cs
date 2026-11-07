using UnityEngine;
using TMPro; // TextMeshPro kullanıyorsanız gerekli

public class ObjectSelector : MonoBehaviour
{
    [Header("Hedef Ayarları")]
    [Tooltip("Çocuk nesnelerini kontrol etmek istediğiniz ana (Parent) nesne")]
    [SerializeField] private Transform parentObject;

    [Header("UI Bileşenleri (İsteğe Bağlı)")]
    [SerializeField] private TMP_InputField indexInputField;

    private int currentIndex = 0;
    private int childCount = 0;

    void Start()
    {
        if (parentObject == null)
        {
            // Eğer atanmadıysa bu betiğin bağlı olduğu nesneyi parent kabul et
            parentObject = this.transform;
        }

        UpdateChildCount();
        SetActiveObject(currentIndex);
    }

    // Çocuk nesnelerin sayısını günceller (Çalışma anında yeni çocuk eklenirse çağrılabilir)
    public void UpdateChildCount()
    {
        childCount = parentObject.childCount;
    }

    // Sonraki nesneye geçiş (Next Butonu için)
    public void NextObject()
    {
        if (childCount == 0) return;

        currentIndex++;
        if (currentIndex >= childCount)
        {
            currentIndex = 0; // Başa dön (Loop)
        }

        SetActiveObject(currentIndex);
    }

    // Önceki nesneye geçiş (Previous Butonu için)
    public void PreviousObject()
    {
        if (childCount == 0) return;

        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = childCount - 1; // Sona git (Loop)
        }

        SetActiveObject(currentIndex);
    }

    // Input Field üzerinden sayı girildiğinde çağrılacak fonksiyon
    public void OnInputFieldSubmit()
    {
        if (indexInputField == null || string.IsNullOrEmpty(indexInputField.text)) return;

        // Girilen metni sayıya çevir (Kullanıcı 1 tabanlı girebilir, indeksler 0 tabanlıdır)
        if (int.TryParse(indexInputField.text, out int targetIndex))
        {
            // Kullanıcı dostu olması için 1. nesne = 0. indeks olarak hesaplıyoruz
            int actualIndex = targetIndex - 1; 

            if (actualIndex >= 0 && actualIndex < childCount)
            {
                currentIndex = actualIndex;
                SetActiveObject(currentIndex);
            }
            else
            {
                Debug.LogWarning($"Geçersiz sıra! Lütfen 1 ile {childCount} arasında bir sayı girin.");
            }
        }
    }

    // Esas aktifleştirme ve devre dışı bırakma mantığı
    private void SetActiveObject(int indexToActive)
    {
        if (childCount == 0) return;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = parentObject.GetChild(i);
            
            // Sadece hedef indeksteki nesneyi aktif yap, diğerlerini kapat
            child.gameObject.SetActive(i == indexToActive);
        }

        // Input alanını güncel tutmak isterseniz (Opsiyonel)
        if (indexInputField != null)
        {
            indexInputField.text = (indexToActive + 1).ToString();
        }
    }
}
