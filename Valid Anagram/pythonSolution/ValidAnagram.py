class Solution:
    def isAnagram(self,s:str,t:str)->bool:
        s=s.lower()
        t=t.lower()
    
        s=s.replace(" ","")
        t=t.replace(" ","")
        
        counts=[0]*26
        for char in s:
            counts[ord(char)-ord('a')]+=1
        for char in t:
            counts[ord(char)-ord('a')]-=1
        for count in counts:
            if count!=0:
                return False
        return True